using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pet1 : MonoBehaviour
{
    public float distance;
    public float speed;
    Transform player;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        Physics2D.IgnoreLayerCollision(0, 3);
    }

    void Update()
    {
        Vector2 targetPosition = new Vector2(player.position.x, player.position.y);
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);

        if (Vector2.Distance(currentPosition, targetPosition) > distance)
        {
            transform.position = Vector2.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
            anim.SetBool("IsWalk", true);
            DirectionPet();
        }
        else
        {
            anim.SetBool("IsWalk", false);
        }
    }

    void DirectionPet()
    {
        if (transform.position.x - player.position.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}