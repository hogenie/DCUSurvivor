using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnReposition : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform ������Ʈ

    void Update()
    {
        // ���� ������Ʈ�� position.y ���� �÷��̾��� ���� position.y ������ ����
        Vector3 newPosition = transform.position;
        newPosition.y = player.position.y;
        transform.position = newPosition;
    }
}
