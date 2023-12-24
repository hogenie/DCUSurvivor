using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SoundHUD : MonoBehaviour
{
    private float oldValue;
    public bool isBgmSliderReset;
    public bool isSfxSliderReset;
    public static SoundHUD instance;
    // 오디오 믹서
    public AudioMixer audioMixer;

    // 슬라이더
    public Slider BgmSlider;
    public Slider SfxSlider;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        // 초기화 시 슬라이더 값을 현재 볼륨 값에 맞춰 설정
        float bgmVolume;
        audioMixer.GetFloat("BGM", out bgmVolume);
        BgmSlider.value = Mathf.Pow(10f, bgmVolume / 20f);

        float sfxVolume;
        audioMixer.GetFloat("SFX", out sfxVolume);
        SfxSlider.value = Mathf.Pow(10f, sfxVolume / 20f);
    }

    // 볼륨 조절
    public void SetBgmVolme()
    {
        // 로그 연산 값 전달
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
    }

    public void SetSFXVolme()
    {
        // 로그 연산 값 전달
        audioMixer.SetFloat("SFX", Mathf.Log10(SfxSlider.value) * 20);
    }

    public void SetBgmVolMute()
    {
        if (!isBgmSliderReset)
        {
            // 현재 슬라이더 값 저장
            oldValue = BgmSlider.value;
            // 슬라이더 값을 0으로 설정
            BgmSlider.value = 0f;
            isBgmSliderReset = true;
        }
        else
        {
            // 이전 값으로 슬라이더 값 복원
            BgmSlider.value = oldValue;
            isBgmSliderReset = false;
        }
    }
    public void SetSFXVolMute()
    {
        if (!isSfxSliderReset)
        {
            // 현재 슬라이더 값 저장
            oldValue = SfxSlider.value;
            // 슬라이더 값을 0으로 설정
            SfxSlider.value = 0f;
            isSfxSliderReset = true;
        }
        else
        {
            // 이전 값으로 슬라이더 값 복원
            SfxSlider.value = oldValue;
            isSfxSliderReset = false;
        }
    }
    
}
