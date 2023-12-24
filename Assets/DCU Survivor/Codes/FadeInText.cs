using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Image class를 사용하기 위해 추가합니다.


public class FadeInText : MonoBehaviour
{
    Text col1;
    public float WaitTime;
    public string textname;

    void Awake()
    {
        GameObject obj1 = GameObject.Find(textname);
        col1 = obj1.GetComponent<Text>();
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
        }
    }
}