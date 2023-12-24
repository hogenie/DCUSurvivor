using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("#BGM")]
    public AudioClip bgmClip;
    public AudioClip BossbgmClip;
    public AudioClip MainbgmClip;
    public float bgmVolume;
    AudioSource bgmPlayer;
    AudioSource BossbgmPlayer;
    AudioHighPassFilter bgmEffect;

    [Header("#SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume;
    public int channels;
    AudioSource[] sfxPlayers;
    int channelIndex;

    private AudioSource audioSource1;
    private AudioSource[] audioSource;
    public AudioMixerGroup audioMixer1, audioMixer2;
    public AudioMixer audiomixer;

    

    public enum Sfx { Dead, Hit, LevelUp=3, Lose, Melee, Range=7, Select, Win }

    void Awake()
    {
        instance = this;
        Init();
    }
   /* void Start()
    {
        PlayMainBgm(true);
    } */ 
    void Init()
    {
        //배경음 플레이어 초기화
        GameObject bgmObject = new GameObject("BgmPlayer");
        bgmObject.transform.parent = transform; 
        bgmPlayer = bgmObject.AddComponent<AudioSource>();

        GameObject BossbgmObject = new GameObject("BossBgmPlayer");
        BossbgmObject.transform.parent = transform;
        BossbgmPlayer = BossbgmObject.AddComponent<AudioSource>();

        audioSource1 = bgmPlayer.GetComponent<AudioSource>();
        audioSource1.outputAudioMixerGroup = audioMixer1;

        audioSource1 = BossbgmPlayer.GetComponent<AudioSource>();
        audioSource1.outputAudioMixerGroup = audioMixer1;

        bgmPlayer.playOnAwake = false;
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        BossbgmPlayer.playOnAwake = false;
        BossbgmPlayer.loop = true;
        BossbgmPlayer.volume = bgmVolume;
        BossbgmPlayer.clip = BossbgmClip;


        //효과음 플레이어 초기화
        GameObject sfxObject = new GameObject("SfxPlayer");
        sfxObject.transform.parent = transform;
        sfxPlayers = new AudioSource[channels];
        audioSource = new AudioSource[channels]; 
        
        for(int index = 0; index < sfxPlayers.Length; index++)
        {
            sfxPlayers[index] = sfxObject.AddComponent<AudioSource>();
            audioSource[index] = sfxPlayers[index];
            audioSource[index].outputAudioMixerGroup = audioMixer2;
            sfxPlayers[index].playOnAwake = false;
            sfxPlayers[index].bypassListenerEffects = true;
            sfxPlayers[index].volume = sfxVolume;
        }

    }

    public void PlayBgm(bool isPlay)
    {
        if (bgmPlayer != null) // AudioSource 객체가 null인지 확인
        {
            if (isPlay)
        {
            bgmPlayer.Play();
        }
        else
        {
            bgmPlayer.Stop();
        }
    }
}
    public void PlayBossBgm(bool isPlay)
    {
        if (BossbgmPlayer != null) // AudioSource 객체가 null인지 확인
        {
            if (isPlay)
        {
            BossbgmPlayer.Play();
        }
        else
        {
            BossbgmPlayer.Stop();
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
    public void ClickSound()
    {
        sfxPlayers[8].Play();
    }

    public void PlaySfx(Sfx sfx)
    {
        for (int index = 0; index < sfxPlayers.Length; index++) 
        {
            int loopIndex = (index + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[loopIndex].isPlaying)
                continue;

            int ranIndex = 0;
            if(sfx==Sfx.Hit || sfx==Sfx.Melee)
            {
                ranIndex = Random.Range(0, 2);
            }

            channelIndex = loopIndex;
            sfxPlayers[loopIndex].clip = sfxClips[(int)sfx + ranIndex];
            sfxPlayers[loopIndex].Play();
            break;
        }
    }
}
