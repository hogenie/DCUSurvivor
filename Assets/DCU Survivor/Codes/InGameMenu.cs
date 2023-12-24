using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //��� ������ ����ϱ� ���� SceneManagement ���ӽ����̽� �߰�


public class InGameMenu : MonoBehaviour
{
    public GameObject pauseMenuCanvas;

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        GameManager.instance.Resume();
        AudioManager.instance.EffectBgm(false);
    }

    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        GameManager.instance.Stop();
        AudioManager.instance.EffectBgm(true);
    }

    public void ToMain()
    {
        SceneManager.LoadScene(0);
        AudioManager.instance.PlayBgm(false);
        AudioManager.instance.PlayBossBgm(false);
        AudioManager.instance.EffectBgm(false);
        GameManager.instance.soundmanager.SetActive(true);
        Time.timeScale = 1;
    }
    public void SettingToMain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void LeaderBoard()
    {
        //��ŷ�� ��� ���� �ۼ�
    }
}
