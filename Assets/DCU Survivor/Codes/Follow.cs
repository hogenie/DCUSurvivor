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
        //WorldToScreenPoin : ���� ���� ������Ʈ ��ġ�� ��ũ�� ��ǥ�� ��ȯ / �ݴ�� ��ȯ�� ����
        rect.position = Camera.main.WorldToScreenPoint(target.position);
    }
}
