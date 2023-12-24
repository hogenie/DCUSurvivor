using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Image class�� ����ϱ� ���� �߰��մϴ�.


public class BossFadeIn : MonoBehaviour
{
    public float WaitTime;
    Image co;
    Image col;
    public string imagename1;
    public string imagename;
    public SpriteRenderer col1;
    public SpriteRenderer col2;
    private CapsuleCollider2D capsuleCollider;
    private void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }
    void Awake()
    {
        GameObject ob = GameObject.Find(imagename1);
        GameObject obj = GameObject.Find(imagename);
        co = ob.GetComponent<Image>();
        col = obj.GetComponent<Image>();
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
            co.color=new Color(co.color.r, co.color.g, co.color.b, fadeCount);
            col.color = new Color(col.color.r, col.color.g, col.color.b, fadeCount);
            col1.color=new Color(col1.color.r, col1.color.g, col1.color.b, fadeCount);
            col2.color = new Color(col2.color.r, col2.color.g, col2.color.b, fadeCount);
        }
        capsuleCollider.enabled = true;
    }
}