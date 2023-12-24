using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   // Image class를 사용하기 위해 추가합니다.


public class ColorChanger : MonoBehaviour
{
    public Button button;
    public Button button2;
    public Button button3;
    public Button button4;
    public Button button5;
    Image col;
    Image col2;
    Image col3;
    Image col4;
    Image col5;
    void Awake()
    {
        col = button.GetComponent<Image>();
        col2 = button2.GetComponent<Image>();
        col3 = button3.GetComponent<Image>();
        col4 = button2.GetComponent<Image>();
        col5 = button3.GetComponent<Image>();
    }

    public void colorchage1()
    {
        col.color = new Color(0.337f, 0.4f, 0.522f, 1f);
        col2.color = new Color(3f / 255f, 78f / 255f, 162f / 255f, 255f / 255f);
        col3.color = new Color(3f / 255f, 78f / 255f, 162f / 255f, 255f / 255f);
        col4.color = new Color(3f / 255f, 78f / 255f, 162f / 255f, 255f / 255f);
        col5.color = new Color(3f / 255f, 78f / 255f, 162f / 255f, 255f / 255f);
    }
}