using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//����Ƽ���� �Լ��� �̸��� ù ��° ���ڴ� �빮��
public class Player : MonoBehaviour
{
    public Vector2 inputVec;//���� Ÿ�� + ���� �̸�(�ǹ� �ο��� �ؼ� �ĺ� �����ϵ��� �̸� ���ϱ�), public�� �̿��� inputvec�� ��ȭ Ȯ��
    public float speed;
    public Scanner scanner;
    public Hand[] hands;
    public RuntimeAnimatorController[] animCon;

    Rigidbody2D rigid;//Rigidbody 2D�� ������ ���� ����
    SpriteRenderer spriter;
    Animator anim;

    void Awake()//������ �� �ѹ��� ����Ǵ� �����ֱ� Awake
    {
        rigid = GetComponent<Rigidbody2D>();//���� ���� �� �ʱ�ȭ, �÷��̾� �ȿ� �ִ� Rigidbody2D�� rigid ������ ��
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>();//(true) //���� �� true�� ������ ��Ȱ��ȭ �� ������Ʈ�� üũ�ȴ�.
    }
    void OnEnable()
    {
        speed *= Character.Speed1 * Character.Speed2 * Character.Speed3;
        anim.runtimeAnimatorController = animCon[GameManager.instance.playerId];    
    }
    void Update() //�ϳ��� �����Ӹ��� �ѹ��� ȣ��Ǵ� �����ֱ� �Լ�(60������ �������� 1�ʿ� 60�� ����ȴ�)
    {
        if (!GameManager.instance.isLive)
            return;

        inputVec.x = Input.GetAxisRaw("Horizontal");//����
        inputVec.y = Input.GetAxisRaw("Vertical");//����
    }

    void FixedUpdate() //���� ���� �����Ӹ��� ȣ��Ǵ� �����ֱ� �Լ�
    {
        if (!GameManager.instance.isLive)
            return;

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime; //normalized - ���� ���� ũ�Ⱑ 1�� �ǵ��� ��ǥ�� ������ ��
                                                                             //�밢������ �̵��ϸ� ���� �̵��Ÿ��� 1���� ��� ������ �� ������ �̵��ϰ� �ȴ�
                                                                             //��, �밢������ �̵��ϴ� �ӵ��� ����, �������� �̵��ϴ� �ӵ��� ���� �ϱ� ���ؼ� ����Ѵ�
                                                                             //fixedDeltaTime - ���� ������ �ϳ��� �Һ��� �ð� FixedUpdate���� ���, DeltaTime - Update���� ���
                                                                             //��ġ �̵� - MovePosition(�̵�), MoveRotation(ȸ��)
        rigid.MovePosition(rigid.position + nextVec);//MovePosition�� ��ġ �̵��̶� ���� ��ġ�� �����־�� �Ѵ�(rigid.position)
    }

    void LateUpdate() //�������� ���� �Ǳ� �� ����Ǵ� �����ֱ� �Լ�
    {
        if (!GameManager.instance.isLive)
            return;

        anim.SetFloat("Speed", inputVec.magnitude);//magnitude : ������ ������ ũ�� ��

        if (inputVec.x != 0) { //�¿� ����Ű�� �ԷµǾ�����, ��(-1), ��(1), ���Է�(0)
            spriter.flipX = inputVec.x > 0; //inputVec.X < 0 �� �� true ���� ���Եȴ�. ���� �ݴ�� �����ص� 5/12
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
            Debug.Log("���Դϴ�.");
            return;
        }

        else if (collision.gameObject.CompareTag("Object"))
        {
            Debug.Log("������Ʈ�Դϴ�.");
            return;
        }

        GameManager.instance.health -= Time.deltaTime * 10;

        if (GameManager.instance.health < 0)
        {
            for(int index=3;index<transform.childCount;index++)//childCount : �ڽ� ������Ʈ�� ����
            {
                //Getchild  : �־��� �ε����� �ڽ� ������Ʈ�� ��ȯ�ϴ� �Լ�
                transform.GetChild(index).gameObject.SetActive(false);
            }
            anim.SetTrigger("Dead"); //�ִϸ����� SetTrigger �Լ��� ���� �ִϸ��̼� ����
            GameManager.instance.GameOver();
        }
    }
}
