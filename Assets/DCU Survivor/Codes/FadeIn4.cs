using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Image class�� ����ϱ� ���� �߰��մϴ�.


public class FadeIn4 : MonoBehaviour
{
    public float WaitTime;
    Image col1;
    Image col2;
    Image col3;
    Image col4;
    Image col5;
    Image col6;
    Image col7;
    Image col8;
    Image col9;
    Image col10;
    Image col11;
    Image col12;
    Text col13;
    Text col14;
    Text col15;
    Text col16;
    Text col17;
    public string imagename1;
    public string imagename2;
    public string imagename3;
    public string imagename4;
    public string imagename5;
    public string imagename6;
    public string imagename7;
    public string imagename8;
    public string imagename9;
    public string imagename10;
    public string imagename11;
    public string imagename12;
    public string textname1;
    public string textname2;
    public string textname3;
    public string textname4;
    public string textname5;
    public Button ableButton1;
    public Button ableButton2;
    public Button ableButton3;
    public Button ableButton4;
    public Button ableButton5;
    public Scrollbar ableScroll;

    void Awake()
    {
        GameObject obj1 = GameObject.Find(imagename1);
        GameObject obj2 = GameObject.Find(imagename2);
        GameObject obj3 = GameObject.Find(imagename3);
        GameObject obj4 = GameObject.Find(imagename4);
        GameObject obj5 = GameObject.Find(imagename5);
        GameObject obj6 = GameObject.Find(imagename6);
        GameObject obj7 = GameObject.Find(imagename7);
        GameObject obj8 = GameObject.Find(imagename8);
        GameObject obj9 = GameObject.Find(imagename9);
        GameObject obj10 = GameObject.Find(imagename10);
        GameObject obj11 = GameObject.Find(imagename11);
        GameObject obj12 = GameObject.Find(imagename12);
        GameObject obj13 = GameObject.Find(textname1);
        GameObject obj14 = GameObject.Find(textname2);
        GameObject obj15 = GameObject.Find(textname3);
        GameObject obj16 = GameObject.Find(textname4);
        GameObject obj17 = GameObject.Find(textname5);
        col1 = obj1.GetComponent<Image>();
        col2 = obj2.GetComponent<Image>();
        col3 = obj3.GetComponent<Image>();
        col4 = obj4.GetComponent<Image>();
        col5 = obj5.GetComponent<Image>();
        col6 = obj6.GetComponent<Image>();
        col7 = obj7.GetComponent<Image>();
        col8 = obj8.GetComponent<Image>();
        col9 = obj9.GetComponent<Image>();
        col10 = obj10.GetComponent<Image>();
        col11 = obj11.GetComponent<Image>();
        col12 = obj12.GetComponent<Image>();
        col13 = obj13.GetComponent<Text>();
        col14 = obj14.GetComponent<Text>();
        col15 = obj15.GetComponent<Text>();
        col16 = obj16.GetComponent<Text>();
        col17 = obj17.GetComponent<Text>();
    }
    void OnEnable()
    {
        StartCoroutine(FadeInCoroutine());
    }
    IEnumerator FadeInCoroutine()
    {
        yield return new WaitForSeconds(WaitTime);
        float fadeCount = 0;
        while(fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            col1.color = new Color(col1.color.r, col1.color.g, col1.color.b, fadeCount);
            col2.color = new Color(col2.color.r, col2.color.g, col2.color.b, fadeCount);
            col3.color = new Color(col3.color.r, col3.color.g, col3.color.b, fadeCount);
            col4.color = new Color(col4.color.r, col4.color.g, col4.color.b, fadeCount);
            col5.color = new Color(col5.color.r, col5.color.g, col5.color.b, fadeCount);
            col6.color = new Color(col6.color.r, col6.color.g, col6.color.b, fadeCount);
            col7.color = new Color(col7.color.r, col7.color.g, col7.color.b, fadeCount);
            col8.color = new Color(col8.color.r, col8.color.g, col8.color.b, fadeCount);
            col9.color = new Color(col9.color.r, col9.color.g, col9.color.b, fadeCount);
            col10.color = new Color(col10.color.r, col10.color.g, col10.color.b, fadeCount);
            col11.color = new Color(col11.color.r, col11.color.g, col11.color.b, fadeCount);
            col12.color = new Color(col12.color.r, col12.color.g, col12.color.b, fadeCount);
            col13.color = new Color(col13.color.r, col13.color.g, col13.color.b, fadeCount);
            col14.color = new Color(col14.color.r, col14.color.g, col14.color.b, fadeCount);
            col15.color = new Color(col15.color.r, col15.color.g, col15.color.b, fadeCount);
            col16.color = new Color(col16.color.r, col16.color.g, col16.color.b, fadeCount);
            col17.color = new Color(col17.color.r, col17.color.g, col17.color.b, fadeCount);
        }
        ableButton1.interactable = true;
        ableButton2.interactable = true;
        ableButton3.interactable = true;
        ableButton4.interactable = true;
        ableButton5.interactable = true;
        ableScroll.interactable = true;
    }
}