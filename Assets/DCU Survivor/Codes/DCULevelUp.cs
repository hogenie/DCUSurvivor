using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //��� ������ ����ϱ� ���� SceneManagement ���ӽ����̽� �߰�
using UnityEngine.UI;

public class DCULevelUp : MonoBehaviour
{
    public static DCULevelUp instance;
    RectTransform rect;
    public Item[] items;
    private void Awake()
    {
        instance = this; //�ڱ��ڽ� this�� �ʱ�ȭ
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
        
        // 1. ��� ������ ��Ȱ��ȭ
        foreach(Item item in items)
        {
            item.gameObject.SetActive(false);
        }

        // 2. ������ �߿��� �����ϰ� 3�� �����۸� Ȱ��ȭ
        int num = 0;
        int[] ran = new int[3];//�������� Ȱ��ȭ �� �������� �ε��� 3���� ���� �迭 ����
        
        while (true)
        {
            ran[0] = Random.Range(0, items.Length);
            ran[1] = Random.Range(0, items.Length);
            ran[2] = Random.Range(0, items.Length);
            
            if ((ran[0] != ran[1] && ran[1] != ran[2] && ran[0] != ran[2]))
            break; //��� �ε����� �ٸ� �� �����
        }

        for(int index=0 ; index < ran.Length; index++)
        {
            Item ranItem = items[ran[index]];
            // 3. ���� �������� ���� �Һ���������� ��ü
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
                        //Debug.Log(num + ", " + ran[index] + "ù ��°");
                    }
                    else
                    {
                        for(int j = 0; j < items.Length; j++)
                        {
                            if (items[j].level != ranItem.data.damages.Length)
                            {
                                items[j].gameObject.SetActive(true);
                                //Debug.Log(j + " ������");
                                break;
                            }
                        }
                    }
                }
                else
                {
                    items[4].gameObject.SetActive(true);    //items[Random.Range(4, 7)].gameObject.SetActive(true); //4,5,6��°�� �Һ�������� ��� �̷������� �ڵ� ����
                    //Debug.Log(index + ", " + ran[index] + "�� ��°");
                }  
            }
            else
            {
                ranItem.gameObject.SetActive(true);
                //Debug.Log(index + ", " + ran[index] + "�� ����");
            }
            
        }

        
    }
}
