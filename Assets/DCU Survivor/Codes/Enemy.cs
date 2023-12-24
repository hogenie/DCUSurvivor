using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public bool isLive;
    public Animator anim;

    public static Enemy instance;

    public float speed;
    public float health;
    public float maxHealth;
    public RuntimeAnimatorController[] animCon;
    public Rigidbody2D target;

    Rigidbody2D rigid;
    Collider2D coll;
    
    SpriteRenderer spriter;
    WaitForFixedUpdate wait;

    void Awake()
    {
        instance = this;
        coll = GetComponent<Collider2D>();
        wait = new WaitForFixedUpdate();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        // GetCurrentAnimatorStateInfo : 현재 상태 정보를 가져오는 함수
        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")) 
            return;

        Vector2 dirVec = target.position - rigid.position; //위치 차이 = 타겟 위치 - 나의 위치
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime; //fixedDeltaTime - 프레임의 영향으로 결과가 달라지지 않도록 사용
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero; //물리 속도가 이동에 영향을 주지 않도록 속도 제거
    }

    void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x; //목표의 x축 값과 자신의 x축 값을 비교하여 작으면 true가 되도록 설정    
    }

    void OnEnable() //스크립트가 활성화 될 때, 호출되는 이벤트 함수
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        coll.enabled = true;
        rigid.simulated = true;
        spriter.sortingOrder = 2;
        anim.SetBool("Dead", false);
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }
    public void Init(BossSpawnData data)
    {
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet") || !isLive) //지금 충돌한 것이 bullet이 맞는지 확인 -> 아니면 return
            return;

        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());

        if (health > 0)
        {
            //체력이 0보다 높음, 히트 액션 등..
            anim.SetTrigger("Hit");
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Hit);
        }
        else
        {
            //체력이 0이하 = dead
            isLive = false;
            coll.enabled = false;
            rigid.simulated = false; //리지드바디의 물리적 비활성화는 .simulated=false이다.
            spriter.sortingOrder = 1;
            anim.SetBool("Dead", true); // SetBool 함수를 통해 죽는 애니메이션 상태로 전환
            GameManager.instance.kill++; //몬스터 사망 시 킬수 증가
            //Test.instance.DeactivateMonster(this);
            GameManager.instance.GetExp(); //킬수 증가와 함께 경험치 함수 호출

            if(GameManager.instance.isLive)
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Dead);
        }

    }

    // 코루틴 Coroutine : 생명 주기와 비동기처럼 실행되는 함수
    IEnumerator KnockBack() // 앞에 I가 붙은 것은 인터페이스, IEnumerator : 코루틴만의 반환형 인터페이스
    {
        //yield: 코루틴의 반환 키워드
        /* yield return null; //1 프레임 쉬기
        yield return new WaitForSeconds(2f); // 2초 쉬기 */
        yield return wait; // 다음 하나의 물리 프레임 딜레이
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos; //플레이어 기준의 반대 방향 : 현재 위치 - 플레이어 위치
        rigid.AddForce(dirVec.normalized * 3,ForceMode2D.Impulse); // 순간적인 힘이므로 ForceMode2D.Impulse 속성 추가
    
    }

    void Dead()
    {
        // 사망할 땐 SetActive 함수를 통한 오브젝트 비활성화
        gameObject.SetActive(false);
    }
}
