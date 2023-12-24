using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Image class�� ����ϱ� ���� �߰��մϴ�.


public class FadeIn2 : MonoBehaviour
{
    public float WaitTime;
    Image col1;
    Image col2;
    Text col3;
    public string imagename;
    public string imagename1;
    public string textname1;

    void Awake()
    {
        GameObject obj = GameObject.Find(imagename);
        GameObject obj1 = GameObject.Find(imagename1);
        GameObject obj2 = GameObject.Find(textname1);
        col1 = obj.GetComponent<Image>();
        col2 = obj1.GetComponent<Image>();
        col3 = obj2.GetComponent<Text>();
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
            
        }
    }
}