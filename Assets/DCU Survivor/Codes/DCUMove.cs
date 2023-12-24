using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DCUMove : MonoBehaviour
{
    public float speed = 5f; // 이동 속도
    public float targetX = -1; // 목표 X 위치

    private bool isMoving = true; // 이동 여부

    void Update()
    {
        if (isMoving)
        {
            // X 축 값 증가
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            // 목표 위치에 도달했는지 확인
            if (transform.localPosition.x >= targetX)
            {
                isMoving = false; // 이동 멈춤
            }
        }
    }
}
