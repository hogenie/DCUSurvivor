using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static float MaxHealth1 //기본 디쿠 능력치
    {
        get { return GameManager.instance.playerId == 0 ? 1.2f : 1f; }
    }
    public static float MaxHealth2 //의대 디쿠 능력치
    {
        get { return GameManager.instance.playerId == 1 ? 1.1f : 1f; }
    }
    public static float Damage1 //의대 디쿠 능력치
    {
        get { return GameManager.instance.playerId == 1 ? 1.05f : 1f; }
    }
    public static float Speed1 //의대 디쿠 능력치
    {
        get { return GameManager.instance.playerId == 1 ? 1.05f : 1f; }
    }
    public static float Speed2 //음대 디쿠 능력치
    {
        get { return GameManager.instance.playerId == 2 ? 1.2f : 1f; }
    }
    public static float Damage2 //신학대 디쿠 능력치
    {
        get { return GameManager.instance.playerId == 3 ? 1.1f : 1f; }
    }
    public static float Speed3 //신학대 디쿠 능력치
    {
        get { return GameManager.instance.playerId == 3 ? 1.1f : 1f; }
    }
    public static float Damage3 //공대 디쿠 능력치
    {
        get { return GameManager.instance.playerId == 4 ? 1.2f : 1f; }
    }
}
