using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType {Exp, Level, Kill, Time, Health, Monsters }
    public InfoType type;
    GameObject Pool;
    Text myText;
    Slider mySlider;
    int monnum;

    void Awake()
    {
        Pool = GameObject.Find("PoolManager");
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }

    void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                //�����̴��� ������ �� : ���� ����ġ / �ִ� ����ġ
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[Mathf.Min(GameManager.instance.level, GameManager.instance.nextExp.Length - 1)];
                mySlider.value = curExp / maxExp;
                break;
            case InfoType.Level:
                // Format : �� ���� ���ڰ��� ������ ������ ���ڿ��� ������ִ� �Լ�
                // ���� ���� ���ڿ��� �� �ڸ��� {����} ���·� �ۼ�
                // F0, F1, F2.... : �Ҽ��� �ڸ��� ����
                myText.text = string.Format("Lv.{0:F0}", GameManager.instance.level + 1);
                break;
            case InfoType.Kill:
                myText.text = string.Format("{0:F0}", GameManager.instance.kill);
                break;
            case InfoType.Time:
                float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime / 60);
                int sec = Mathf.FloorToInt(remainTime % 60);
                if (min < 0)
                    min = 0;
                if (sec < 0)
                    sec = 0;
                myText.text = string.Format("{0:D2}:{1:D2}", min, sec); //D0, D1, D2.... : �ڸ� ���� ����
                break;
            case InfoType.Health:
                float curHealth = GameManager.instance.health;
                float maxHealth = GameManager.instance.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;
            case InfoType.Monsters:
                monnum = Pool.transform.childCount;
                myText.text = monnum.ToString();
                break;
        }    
    }
}
