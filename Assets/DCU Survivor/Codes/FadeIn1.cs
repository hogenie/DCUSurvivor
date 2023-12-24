using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Image class�� ����ϱ� ���� �߰��մϴ�.


public class FadeIn1 : MonoBehaviour
{
    Image co;
    Image col;
    Text col1;
    Text col2;
    Text col3;
    public string imagename1;
    public string imagename;
    public string textname1;
    public string textname2;
    public string textname3;

    void Awake()
    {
        GameObject ob = GameObject.Find(imagename1);
        GameObject obj = GameObject.Find(imagename);
        GameObject obj1 = GameObject.Find(textname1);
        GameObject obj2 = GameObject.Find(textname2);
        GameObject obj3 = GameObject.Find(textname3);
        co = ob.GetComponent<Image>();
        col = obj.GetComponent<Image>();
        col1 = obj1.GetComponent<Text>();
        col2 = obj2.GetComponent<Text>();
        col3 = obj3.GetComponent<Text>();
    }
    void OnEnable()
    {
        StartCoroutine(FadeInCoroutine());
    }
    IEnumerator FadeInCoroutine()
    {
        float fadeCount = 0;
        while(fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            co.color=new Color(co.color.r, co.color.g, co.color.b, fadeCount);
            col.color = new Color(col.color.r, col.color.g, col.color.b, fadeCount);
            col1.color = new Color(col1.color.r, col1.color.g, col1.color.b, fadeCount);
            col2.color = new Color(col1.color.r, col1.color.g, col1.color.b, fadeCount);
            col3.color = new Color(col1.color.r, col1.color.g, col1.color.b, fadeCount);
            
        }
    }
}