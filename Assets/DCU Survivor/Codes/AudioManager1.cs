using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager1 : MonoBehaviour
{
    public static AudioManager1 instance;

    [Header("#BGM")]
    public AudioClip MainbgmClip;
    public float bgmVolume;
    AudioSource MainbgmPlayer;
    AudioHighPassFilter bgmEffect;

    private AudioSource audioSource1;
    private AudioSource[] audioSource;
    public AudioMixerGroup audioMixer1;
    public AudioMixer audiomixer;

    void Awake()
    {
        instance = this;
        Init();
    }
    void OnEnable()
    {
        PlayMainBgm(true);
    }
    void Init()
    {
        GameObject MainbgmObject = new GameObject("MainBgmPlayer");
        MainbgmObject.transform.parent = transform;
        MainbgmPlayer = MainbgmObject.AddComponent<AudioSource>();

        audioSource1 = MainbgmPlayer.GetComponent<AudioSource>();
        audioSource1.outputAudioMixerGroup = audioMixer1;
        bgmEffect = Camera.main.GetComponent<AudioHighPassFilter>();

        MainbgmPlayer.playOnAwake = false;
        MainbgmPlayer.loop = true;
        MainbgmPlayer.volume = bgmVolume;
        MainbgmPlayer.clip = MainbgmClip;
    }
    public void PlayMainBgm(bool isPlay)
    {
        if (MainbgmPlayer != null) // AudioSource 객체가 null인지 확인
        {
            if (isPlay)
            {
                MainbgmPlayer.Play();
            }
            else
            {
                MainbgmPlayer.Stop();
            }
        }
    }
    public void EffectBgm(bool isPlay)
    {
        if (isPlay)
        {
            audiomixer.SetFloat("BGM_HighPassCutoff", 5000f);
        }
        else
        {
            audiomixer.SetFloat("BGM_HighPassCutoff", 10f);
        }
    }
}