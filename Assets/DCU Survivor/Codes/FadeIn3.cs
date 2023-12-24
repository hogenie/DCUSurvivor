using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Image class�� ����ϱ� ���� �߰��մϴ�.


public class FadeIn3 : MonoBehaviour
{
    public float WaitTime;
    Image col1;
    Image col2;
    Image col3;
    Image col4;
    Image col5;
    Text col6;
    Text col7;
    public string imagename1;
    public string imagename2;
    public string imagename3;
    public string imagename4;
    public string imagename5;
    public string textname1;
    public string textname2;
    public Button ableButton1;
    public Button ableButton2;

    void Awake()
    {
        GameObject obj1 = GameObject.Find(imagename1);
        GameObject obj2 = GameObject.Find(imagename2);
        GameObject obj3 = GameObject.Find(imagename3);
        GameObject obj4 = GameObject.Find(imagename4);
        GameObject obj5 = GameObject.Find(imagename5);
        GameObject obj6 = GameObject.Find(textname1);
        GameObject obj7 = GameObject.Find(textname2);
        col1 = obj1.GetComponent<Image>();
        col2 = obj2.GetComponent<Image>();
        col3 = obj3.GetComponent<Image>();
        col4 = obj4.GetComponent<Image>();
        col5 = obj5.GetComponent<Image>();
        col6 = obj6.GetComponent<Text>();
        col7 = obj7.GetComponent<Text>();
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
        }
        ableButton1.interactable = true;
        ableButton2.interactable = true;
    }
}