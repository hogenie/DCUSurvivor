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

        // GetCurrentAnimatorStateInfo : ���� ���� ������ �������� �Լ�
        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit")) 
            return;

        Vector2 dirVec = target.position - rigid.position; //��ġ ���� = Ÿ�� ��ġ - ���� ��ġ
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime; //fixedDeltaTime - �������� �������� ����� �޶����� �ʵ��� ���
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero; //���� �ӵ��� �̵��� ������ ���� �ʵ��� �ӵ� ����
    }

    void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        if (!isLive)
            return;

        spriter.flipX = target.position.x < rigid.position.x; //��ǥ�� x�� ���� �ڽ��� x�� ���� ���Ͽ� ������ true�� �ǵ��� ����    
    }

    void OnEnable() //��ũ��Ʈ�� Ȱ��ȭ �� ��, ȣ��Ǵ� �̺�Ʈ �Լ�
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
        if (!collision.CompareTag("Bullet") || !isLive) //���� �浹�� ���� bullet�� �´��� Ȯ�� -> �ƴϸ� return
            return;

        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());

        if (health > 0)
        {
            //ü���� 0���� ����, ��Ʈ �׼� ��..
            anim.SetTrigger("Hit");
            AudioManager.instance.PlaySfx(AudioManager.Sfx.Hit);
        }
        else
        {
            //ü���� 0���� = dead
            isLive = false;
            coll.enabled = false;
            rigid.simulated = false; //������ٵ��� ������ ��Ȱ��ȭ�� .simulated=false�̴�.
            spriter.sortingOrder = 1;
            anim.SetBool("Dead", true); // SetBool �Լ��� ���� �״� �ִϸ��̼� ���·� ��ȯ
            GameManager.instance.kill++; //���� ��� �� ų�� ����
            //Test.instance.DeactivateMonster(this);
            GameManager.instance.GetExp(); //ų�� ������ �Բ� ����ġ �Լ� ȣ��

            if(GameManager.instance.isLive)
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Dead);
        }

    }

    // �ڷ�ƾ Coroutine : ���� �ֱ�� �񵿱�ó�� ����Ǵ� �Լ�
    IEnumerator KnockBack() // �տ� I�� ���� ���� �������̽�, IEnumerator : �ڷ�ƾ���� ��ȯ�� �������̽�
    {
        //yield: �ڷ�ƾ�� ��ȯ Ű����
        /* yield return null; //1 ������ ����
        yield return new WaitForSeconds(2f); // 2�� ���� */
        yield return wait; // ���� �ϳ��� ���� ������ ������
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos; //�÷��̾� ������ �ݴ� ���� : ���� ��ġ - �÷��̾� ��ġ
        rigid.AddForce(dirVec.normalized * 3,ForceMode2D.Impulse); // �������� ���̹Ƿ� ForceMode2D.Impulse �Ӽ� �߰�
    
    }

    void Dead()
    {
        // ����� �� SetActive �Լ��� ���� ������Ʈ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
