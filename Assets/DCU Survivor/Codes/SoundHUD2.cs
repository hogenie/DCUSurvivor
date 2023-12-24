using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SoundHUD2 : MonoBehaviour
{
    // 오디오 믹서
    public AudioMixer audioMixer;

    // 스피커 아이콘
    public GameObject speakericon1;
    public GameObject speakericon2;
    public GameObject speakericon3;
    public GameObject speakericon4;

    public float activationThreshold1 = 0.22f;
    public float activationThreshold2 = 0.66f;

    // 슬라이더
    public Slider SfxSlider;

    private void Start()
    {
        // 슬라이더 값 변경 시 이벤트에 메소드 연결
        SfxSlider.onValueChanged.AddListener(OnSlider2ValueChanged);
    }

    public void SetSFXVolme()
    {
        // 로그 연산 값 전달
        audioMixer.SetFloat("SFX", Mathf.Log10(SfxSlider.value) * 20);
    }
    private void OnSlider2ValueChanged(float value)
    {
        if (value >= activationThreshold2)
        {
            speakericon1.SetActive(true);
            speakericon2.SetActive(true);
            speakericon3.SetActive(true);
            speakericon4.SetActive(false);
        }
        else if (value<activationThreshold2 && value >= activationThreshold1)
        {
            speakericon1.SetActive(true);
            speakericon2.SetActive(true);
            speakericon3.SetActive(false);
            speakericon4.SetActive(false);
        }
        else if (value<activationThreshold1)
        {
            speakericon1.SetActive(true);
            speakericon2.SetActive(false);
            speakericon3.SetActive(false);
            speakericon4.SetActive(false);
        }
        else if(value <= SfxSlider.minValue)
        {
            speakericon1.SetActive(true);
            speakericon2.SetActive(false);
            speakericon3.SetActive(false);
            speakericon4.SetActive(true);
        }
    }
}
