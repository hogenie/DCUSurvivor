using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static float MaxHealth1 //�⺻ ���� �ɷ�ġ
    {
        get { return GameManager.instance.playerId == 0 ? 1.2f : 1f; }
    }
    public static float MaxHealth2 //�Ǵ� ���� �ɷ�ġ
    {
        get { return GameManager.instance.playerId == 1 ? 1.1f : 1f; }
    }
    public static float Damage1 //�Ǵ� ���� �ɷ�ġ
    {
        get { return GameManager.instance.playerId == 1 ? 1.05f : 1f; }
    }
    public static float Speed1 //�Ǵ� ���� �ɷ�ġ
    {
        get { return GameManager.instance.playerId == 1 ? 1.05f : 1f; }
    }
    public static float Speed2 //���� ���� �ɷ�ġ
    {
        get { return GameManager.instance.playerId == 2 ? 1.2f : 1f; }
    }
    public static float Damage2 //���д� ���� �ɷ�ġ
    {
        get { return GameManager.instance.playerId == 3 ? 1.1f : 1f; }
    }
    public static float Speed3 //���д� ���� �ɷ�ġ
    {
        get { return GameManager.instance.playerId == 3 ? 1.1f : 1f; }
    }
    public static float Damage3 //���� ���� �ɷ�ġ
    {
        get { return GameManager.instance.playerId == 4 ? 1.2f : 1f; }
    }
}
