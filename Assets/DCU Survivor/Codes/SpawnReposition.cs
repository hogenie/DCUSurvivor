using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnReposition : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform 컴포넌트

    void Update()
    {
        // 현재 오브젝트의 position.y 값을 플레이어의 현재 position.y 값으로 설정
        Vector3 newPosition = transform.position;
        newPosition.y = player.position.y;
        transform.position = newPosition;
    }
}
