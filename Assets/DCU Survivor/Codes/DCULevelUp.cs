using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //장면 관리를 사용하기 위해 SceneManagement 네임스페이스 추가
using UnityEngine.UI;

public class DCULevelUp : MonoBehaviour
{
    public static DCULevelUp instance;
    RectTransform rect;
    public Item[] items;
    private void Awake()
    {
        instance = this; //자기자신 this로 초기화
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true);
    }

    public void Show()
    {
        Next();
        rect.localScale = Vector3.one; //(1,1,1)
        GameManager.instance.Stop();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.LevelUp);
        AudioManager.instance.EffectBgm(true);
    }
    public void Hide()
    {
        rect.localScale = Vector3.zero; //(0,0,0)
        GameManager.instance.Resume();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Select);
        AudioManager.instance.EffectBgm(false);
    }

    public void Select(int index)
    {
        items[index].OnClick();
    }
    void Next()
    {
        
        // 1. 모든 아이템 비활성화
        foreach(Item item in items)
        {
            item.gameObject.SetActive(false);
        }

        // 2. 아이템 중에서 랜덤하게 3개 아이템만 활성화
        int num = 0;
        int[] ran = new int[3];//랜덤으로 활성화 할 아이템의 인덱스 3개를 담을 배열 선언
        
        while (true)
        {
            ran[0] = Random.Range(0, items.Length);
            ran[1] = Random.Range(0, items.Length);
            ran[2] = Random.Range(0, items.Length);
            
            if ((ran[0] != ran[1] && ran[1] != ran[2] && ran[0] != ran[2]))
            break; //모든 인덱스가 다를 때 멈춰라
        }

        for(int index=0 ; index < ran.Length; index++)
        {
            Item ranItem = items[ran[index]];
            // 3. 만렙 아이템의 경우는 소비아이템으로 대체
            if (ranItem.level == ranItem.data.damages.Length || ran[index] == 4) 
            {
                if (items[4].gameObject.activeSelf == true)
                {
                    int count = 0;
                    for(int i = 0; i < items.Length; i++)
                    {
                        if (items[i].level == ranItem.data.damages.Length)  
                        count++;
                    }
                    if (count < 3)
                    {
                        while (true)
                        {
                            num = Random.Range(0, items.Length);
                            if (num != ran[0] && num != ran[1] && num != ran[2] && num != 4 && items[num].gameObject.activeSelf != true && items[num].level != ranItem.data.damages.Length)    
                                break;
                        }
                        items[num].gameObject.SetActive(true);
                        //Debug.Log(num + ", " + ran[index] + "첫 번째");
                    }
                    else
                    {
                        for(int j = 0; j < items.Length; j++)
                        {
                            if (items[j].level != ranItem.data.damages.Length)
                            {
                                items[j].gameObject.SetActive(true);
                                //Debug.Log(j + " 마지막");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    items[4].gameObject.SetActive(true);    //items[Random.Range(4, 7)].gameObject.SetActive(true); //4,5,6번째가 소비아이템일 경우 이런식으로 코드 구성
                    //Debug.Log(index + ", " + ran[index] + "두 번째");
                }  
            }
            else
            {
                ranItem.gameObject.SetActive(true);
                //Debug.Log(index + ", " + ran[index] + "세 번쨰");
            }
            
        }

        
    }
}
