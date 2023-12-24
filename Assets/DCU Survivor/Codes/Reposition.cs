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


    void OnTriggerExit2D(Collider2D collision) //trigger�� üũ�� Collider���� ������ �� ����Ǵ� ��
    {
        /* float diffX = Mathf.Abs(playerPos.x - myPos.x); //Mathf.Abs() ��ȣ ���� ���� ����
        float diffY = Mathf.Abs(playerPos.y - myPos.y); //�÷��̾�� Ÿ���� diffX, diffY x,y��ǥ ���� ����

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
                if(coll.enabled) //collider�� Ȱ��ȭ �Ǿ� ������ true ��Ȱ��ȭ�� false
                {
                    transform.Translate(Vector3.up * dirY * 60);
                }
                break;
            
        }
    }
}
