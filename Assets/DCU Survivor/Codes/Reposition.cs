using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>();    
    }


    void OnTriggerExit2D(Collider2D collision) //trigger가 체크된 Collider에서 나갔을 때 실행되는 것
    {
        /* float diffX = Mathf.Abs(playerPos.x - myPos.x); //Mathf.Abs() 괄호 안의 값의 절댓값
        float diffY = Mathf.Abs(playerPos.y - myPos.y); //플레이어와 타일의 diffX, diffY x,y좌표 값의 차이

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1; */

        GameObject camera = GameObject.FindWithTag("Camera");
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        Vector3 playerDir = GameManager.instance.player.inputVec;

        float dirX = playerPos.x - myPos.x;
        float dirY = playerPos.y - myPos.y;

        float diffX = Mathf.Abs(dirX);
        float diffY = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    return;
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 120);
                    camera.transform.Translate(Vector3.up * dirY * 60);
                }
                break;
            case "Wall":
                if (diffX > diffY)
                {
                    return;
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 120);
                }
                break;
            case "Object":
                if (diffX > diffY)
                {
                    return;
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 120);
                }
                break;
            case "Enemy":
                if(coll.enabled) //collider가 활성화 되어 있으면 true 비활성화면 false
                {
                    transform.Translate(Vector3.up * dirY * 60);
                }
                break;
            
        }
    }
}
