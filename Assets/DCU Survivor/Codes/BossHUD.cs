using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHUD : MonoBehaviour
{
    Slider mySlider;

    void Awake()
    {
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        float curBossHealth = GameManager.instance.Boss.health;
        float maxBossHealth = GameManager.instance.Boss.maxHealth;
        mySlider.value = curBossHealth / maxBossHealth;
    }
}
