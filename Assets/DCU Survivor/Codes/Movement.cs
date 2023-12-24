using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Movement: MonoBehaviour
{
    public Rigidbody2D target;
    NavMeshAgent agent;
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;
        if (!Enemy.instance.isLive || Enemy.instance.anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            agent.isStopped = true;
            return;
        }
        SetAgentPosition();
    }
    void OnEnable() //스크립트가 활성화 될 때, 호출되는 이벤트 함수
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        agent.speed = 1f;
    }
    void SetAgentPosition()
    {
        agent.speed = 1f;
        agent.SetDestination(new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z));
    }
    
}
