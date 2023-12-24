using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SoundHUD2 : MonoBehaviour
{
    // ����� �ͼ�
    public AudioMixer audioMixer;

    // ����Ŀ ������
    public GameObject speakericon1;
    public GameObject speakericon2;
    public GameObject speakericon3;
    public GameObject speakericon4;

    public float activationThreshold1 = 0.22f;
    public float activationThreshold2 = 0.66f;

    // �����̴�
    public Slider SfxSlider;

    private void Start()
    {
        // �����̴� �� ���� �� �̺�Ʈ�� �޼ҵ� ����
        SfxSlider.onValueChanged.AddListener(OnSlider2ValueChanged);
    }

    public void SetSFXVolme()
    {
        // �α� ���� �� ����
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
