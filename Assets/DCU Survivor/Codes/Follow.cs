using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform rect;
    public Transform target;
    void Awake()
    {
        rect = GetComponent<RectTransform>();    
    }
    void FixedUpdate()
    {
        //WorldToScreenPoin : 월드 상의 오브젝트 위치를 스크린 좌표로 변환 / 반대로 전환도 가능
        rect.position = Camera.main.WorldToScreenPoint(target.position);
    }
}
