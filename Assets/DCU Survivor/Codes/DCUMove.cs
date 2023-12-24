using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DCUMove : MonoBehaviour
{
    public float speed = 5f; // �̵� �ӵ�
    public float targetX = -1; // ��ǥ X ��ġ

    private bool isMoving = true; // �̵� ����

    void Update()
    {
        if (isMoving)
        {
            // X �� �� ����
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // ��ǥ ��ġ�� �����ߴ��� Ȯ��
            if (transform.localPosition.x >= targetX)
            {
                isMoving = false; // �̵� ����
            }
        }
    }
}
