using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public int per;//관통 확률 (-1일 때는 근접 무기 즉, 관통에 대한 개념이 없어짐)

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    
    }

    public void Init(float damage,int per, Vector3 dir)
    {
        //왼쪽에 있는 damage(per)는 불릿 안에 있는 damage(per), 오른쪽에 있는 damage(per)는 지금 받고 있는 매개변수의 damage(per)
        this.damage = damage;
        this.per = per;

        if(per > -1) 
        {
            rigid.velocity = dir * 15f;
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || per == -1) 
            return;
        
        per--;

        if (per == -1)
        {
            rigid.velocity = Vector2.zero; //초기화
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        Dead(); // 총알이 플레이어와 일정 거리 이상 멀어지면 비활성화
    }
    void Dead()
    {
        Transform target = GameManager.instance.player.transform;
        Vector3 targetPos = target.position;
        float dir = Vector3.Distance(targetPos,transform.position);
        if (dir > 20f)
            this.gameObject.SetActive(false);
    }
}
