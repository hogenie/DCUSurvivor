using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Image class�� ����ϱ� ���� �߰��մϴ�.


public class FadeIn5 : MonoBehaviour
{
    public float WaitTime;
    Image col1;
    Image col2;
    Text col13;
    Text col14;
    Text col15;
    Text col16;
    Text col17;
    public string imagename1;
    public string imagename2;
    public string textname1;
    public string textname2;
    public string textname3;
    public string textname4;
    public string textname5;

    void Awake()
    {
        GameObject obj1 = GameObject.Find(imagename1);
        GameObject obj2 = GameObject.Find(imagename2);
        GameObject obj13 = GameObject.Find(textname1);
        GameObject obj14 = GameObject.Find(textname2);
        GameObject obj15 = GameObject.Find(textname3);
        GameObject obj16 = GameObject.Find(textname4);
        GameObject obj17 = GameObject.Find(textname5);
        col1 = obj1.GetComponent<Image>();
        col2 = obj2.GetComponent<Image>();
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
            col13.color = new Color(col13.color.r, col13.color.g, col13.color.b, fadeCount);
            col14.color = new Color(col14.color.r, col14.color.g, col14.color.b, fadeCount);
            col15.color = new Color(col15.color.r, col15.color.g, col15.color.b, fadeCount);
            col16.color = new Color(col16.color.r, col16.color.g, col16.color.b, fadeCount);
            col17.color = new Color(col17.color.r, col17.color.g, col17.color.b, fadeCount);
        }
    }
}