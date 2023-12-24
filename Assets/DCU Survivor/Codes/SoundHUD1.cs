using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SoundHUD1 : MonoBehaviour
{
    // 오디오 믹서
    public AudioMixer audioMixer;

    // 스피커 아이콘
    public GameObject speakericon1;
    public GameObject speakericon2;
    public GameObject speakericon3;
    public GameObject speakericon4;

    float activationThreshold1 = 0.22f;
    float activationThreshold2 = 0.66f;
    float activationThreshold3 = 0.0005f;

    // 슬라이더
    public Slider BgmSlider;

    private void Start()
    {
        // 슬라이더 값 변경 시 이벤트에 메소드 연결
        BgmSlider.onValueChanged.AddListener(OnSlider1ValueChanged);
    }


    // 볼륨 조절
    public void SetBgmVolme()
    {
        // 로그 연산 값 전달
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
    }
    private void OnSlider1ValueChanged(float value)
    {
        if (value >= activationThreshold2)
        {
            speakericon1.SetActive(true);
            speakericon2.SetActive(true);
            speakericon3.SetActive(true);
            speakericon4.SetActive(false);
        }
        else if (value < activationThreshold2 && value >= activationThreshold1)
        {
            speakericon1.SetActive(true);
            speakericon2.SetActive(true);
            speakericon3.SetActive(false);
            speakericon4.SetActive(false);
        }
        else if (value < activationThreshold1)
        {
            speakericon1.SetActive(true);
            speakericon2.SetActive(false);
            speakericon3.SetActive(false);
            speakericon4.SetActive(false);
        }
        else if (value <= activationThreshold3)
        {
            speakericon1.SetActive(true);
            speakericon2.SetActive(false);
            speakericon3.SetActive(false);
            speakericon4.SetActive(true);
        }
    }
}
