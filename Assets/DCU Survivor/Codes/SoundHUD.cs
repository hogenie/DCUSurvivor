using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SoundHUD : MonoBehaviour
{
    private float oldValue;
    public bool isBgmSliderReset;
    public bool isSfxSliderReset;
    public static SoundHUD instance;
    // ����� �ͼ�
    public AudioMixer audioMixer;

    // �����̴�
    public Slider BgmSlider;
    public Slider SfxSlider;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        // �ʱ�ȭ �� �����̴� ���� ���� ���� ���� ���� ����
        float bgmVolume;
        audioMixer.GetFloat("BGM", out bgmVolume);
        BgmSlider.value = Mathf.Pow(10f, bgmVolume / 20f);

        float sfxVolume;
        audioMixer.GetFloat("SFX", out sfxVolume);
        SfxSlider.value = Mathf.Pow(10f, sfxVolume / 20f);
    }

    // ���� ����
    public void SetBgmVolme()
    {
        // �α� ���� �� ����
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
    }

    public void SetSFXVolme()
    {
        // �α� ���� �� ����
        audioMixer.SetFloat("SFX", Mathf.Log10(SfxSlider.value) * 20);
    }

    public void SetBgmVolMute()
    {
        if (!isBgmSliderReset)
        {
            // ���� �����̴� �� ����
            oldValue = BgmSlider.value;
            // �����̴� ���� 0���� ����
            BgmSlider.value = 0f;
            isBgmSliderReset = true;
        }
        else
        {
            // ���� ������ �����̴� �� ����
            BgmSlider.value = oldValue;
            isBgmSliderReset = false;
        }
    }
    public void SetSFXVolMute()
    {
        if (!isSfxSliderReset)
        {
            // ���� �����̴� �� ����
            oldValue = SfxSlider.value;
            // �����̴� ���� 0���� ����
            SfxSlider.value = 0f;
            isSfxSliderReset = true;
        }
        else
        {
            // ���� ������ �����̴� �� ����
            SfxSlider.value = oldValue;
            isSfxSliderReset = false;
        }
    }
    
}
