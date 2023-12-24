using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//유니티에서 함수의 이름의 첫 번째 글자는 대문자
public class Player : MonoBehaviour
{
    public Vector2 inputVec;//변수 타입 + 변수 이름(의미 부여를 해서 식별 가능하도록 이름 정하기), public을 이용해 inputvec값 변화 확인
    public float speed;
    public Scanner scanner;
    public Hand[] hands;
    public RuntimeAnimatorController[] animCon;

    Rigidbody2D rigid;//Rigidbody 2D를 저장할 변수 선언
    SpriteRenderer spriter;
    Animator anim;

    void Awake()//시작할 때 한번만 실행되는 생명주기 Awake
    {
        rigid = GetComponent<Rigidbody2D>();//변수 선언 후 초기화, 플레이어 안에 있는 Rigidbody2D가 rigid 변수에 들어감
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>();//(true) //인자 값 true를 넣으면 비활성화 된 오브젝트도 체크된다.
    }
    void OnEnable()
    {
        speed *= Character.Speed1 * Character.Speed2 * Character.Speed3;
        anim.runtimeAnimatorController = animCon[GameManager.instance.playerId];    
    }
    void Update() //하나의 프레임마다 한번씩 호출되는 생명주기 함수(60프레임 기준으로 1초에 60번 실행된다)
    {
        if (!GameManager.instance.isLive)
            return;

        inputVec.x = Input.GetAxisRaw("Horizontal");//수평
        inputVec.y = Input.GetAxisRaw("Vertical");//수직
    }

    void FixedUpdate() //물리 연산 프레임마다 호출되는 생명주기 함수
    {
        if (!GameManager.instance.isLive)
            return;

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; //normalized - 벡터 값의 크기가 1이 되도록 좌표가 수정된 값
                                                                             //대각선으로 이동하면 실제 이동거리는 1보다 길기 때문에 더 빠르게 이동하게 된다
                                                                             //즉, 대각선으로 이동하는 속도도 수평, 수직으로 이동하는 속도와 같게 하기 위해서 사용한다
                                                                             //fixedDeltaTime - 물리 프레임 하나가 소비한 시간 FixedUpdate에서 사용, DeltaTime - Update에서 사용
                                                                             //위치 이동 - MovePosition(이동), MoveRotation(회전)
        rigid.MovePosition(rigid.position + nextVec);//MovePosition은 위치 이동이라 현재 위치도 더해주어야 한다(rigid.position)
    }

    void LateUpdate() //프레임이 종료 되기 전 실행되는 생명주기 함수
    {
        if (!GameManager.instance.isLive)
            return;

        anim.SetFloat("Speed", inputVec.magnitude);//magnitude : 벡터의 순수한 크기 값

        if (inputVec.x != 0) { //좌우 방향키가 입력되었을때, 좌(-1), 우(1), 무입력(0)
            spriter.flipX = inputVec.x > 0; //inputVec.X < 0 일 때 true 값이 들어가게된다. 지금 반대로 적용해둠 5/12
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!GameManager.instance.isLive) 
        { 
            return; 
        }
            
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("벽입니다.");
            return;
        }

        else if (collision.gameObject.CompareTag("Object"))
        {
            Debug.Log("오브젝트입니다.");
            return;
        }

        GameManager.instance.health -= Time.deltaTime * 10;

        if (GameManager.instance.health < 0)
        {
            for(int index=3;index<transform.childCount;index++)//childCount : 자식 오브젝트의 개수
            {
                //Getchild  : 주어진 인덱스의 자식 오브젝트를 반환하는 함수
                transform.GetChild(index).gameObject.SetActive(false);
            }
            anim.SetTrigger("Dead"); //애니메이터 SetTrigger 함수로 죽음 애니메이션 실행
            GameManager.instance.GameOver();
        }
    }
}
