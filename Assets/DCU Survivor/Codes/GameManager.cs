using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //장면 관리를 사용하기 위해 SceneManagement 네임스페이스 추가
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject soundmanager;

    [Header("# Game Control")]//Header : 인스펙터의 속성들을 이쁘게 구분시켜주는 타이틀
    public bool isLive;
    public float gameTime;
    public float maxGameTime = 10 * 60f; //20초

    [Header("# Player Info")]
    public int playerId;
    public float health;
    public float maxHealth = 100;
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 }; //각 레벨의 필요경험치를 보관할 배열 변수 선언 및 초기화


    [Header("# Game Object")]
    public PoolManager pool;
    public Player player;
    public DCULevelUp uiLevelUp;
    public Result uiResult;
    public GameObject enemyCleaner;

    [Header("# Boss")]
    public GameObject MapSpawner;
    public GameObject BossUi;
    private bool BossSpawned = false;

    [Header("# Boss Spawn")]
    public Transform parentTransform;
    public GameObject BossObj;
    public Enemy Boss;
    public GameObject BossHP;
    public GameObject Infinity1;
    public GameObject Infinity2;
    public GameObject Limit1;
    public GameObject Limit2;

    /*[Header("# UI Select")]
    public GameObject[] UIs;*/

    [Header("# LevelUp Sys")]
    public ItemData[] NormalDiku;
    public ItemData[] DoctorDiku;
    public ItemData[] MusicDiku;
    public ItemData[] CatolicDiku;
    public ItemData[] BatteryDiku;
    public Item[] LevelUPItems;

    [Header("# LeaderBoard")]
    public GameObject Leaderboard;
    public GameObject LeaderboardInput;

    public GameObject pet;
    void Awake()
    {
        soundmanager = GameObject.Find("AudioManager (1)");
        instance = this; //자기자신 this로 초기화
    }
    public void GameStart()
    {
        health = maxHealth * Character.MaxHealth1 * Character.MaxHealth2;
        Resume();

        soundmanager.SetActive(false);
        AudioManager.instance.PlayBgm(true);
    }
    public void CharaterClick(int id)
    {
        playerId = id;
        switch (playerId)
        {
            case 0:
                Item.instance.DataChange1();
                break;
            case 1:
                Item.instance.DataChange1();
                break;
            case 2:
                Item.instance.DataChange1();
                break;
            case 3:
                Item.instance.DataChange1();
                break;
            case 4:
                Item.instance.DataChange1();
                break;
            default:
                break;
        }
    }
    public void CharaterSelect()
    {
        //UIs[playerId].SetActive(true);
        switch (playerId)
        {
            case 0:
                PoolManager.instance.prefabs[1] = PoolManager.instance.Weaponprefabs[0];
                PoolManager.instance.prefabs[2] = PoolManager.instance.Weaponprefabs[1];
                uiLevelUp.Select(playerId % 2);
                break;
            case 1:
                PoolManager.instance.prefabs[1] = PoolManager.instance.Weaponprefabs[2];
                PoolManager.instance.prefabs[2] = PoolManager.instance.Weaponprefabs[3];
                DCULevelUp.instance.Select(0);
                break;
            case 2:
                PoolManager.instance.prefabs[1] = PoolManager.instance.Weaponprefabs[4];
                PoolManager.instance.prefabs[2] = PoolManager.instance.Weaponprefabs[5];
                uiLevelUp.Select(playerId % 2);
                break;
            case 3:
                PoolManager.instance.prefabs[1] = PoolManager.instance.Weaponprefabs[6];
                PoolManager.instance.prefabs[2] = PoolManager.instance.Weaponprefabs[7];
                uiLevelUp.Select(playerId % 2);
                break;
            case 4:
                PoolManager.instance.prefabs[1] = PoolManager.instance.Weaponprefabs[8];
                PoolManager.instance.prefabs[2] = PoolManager.instance.Weaponprefabs[9];
                uiLevelUp.Select(playerId % 2);
                break;
            default:
                break;
        }
        Item.instance.init();
    }
    public void GameRetry()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void GameOver() 
    {
        StartCoroutine(GameOverRoutine());
    }
    // 딜레이를 위해 게임오버 코루틴도 작성
    IEnumerator GameOverRoutine() //플레이어의 체력이 0이되어 게임이 끝남
    {

        uiResult.gameObject.SetActive(true);
        uiResult.Lose();
        Leaderboard.SetActive(true);
        yield return new WaitForSeconds(1.2f);

        isLive = false;
        Stop();

        AudioManager.instance.PlayBgm(false);
        AudioManager.instance.PlayBossBgm(false);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Lose);
    }
    public void BossStage()
    {
        if (Infinity1.activeSelf || Infinity2.activeSelf)
        {
            StartCoroutine(InfinityBossappearance());
        }
        else if (Limit1.activeSelf || Limit2.activeSelf)  
        {
            StartCoroutine(LimitBossappearance());
        }
    }
    IEnumerator InfinityBossappearance()
    {
        AudioManager.instance.PlayBgm(false);
        AudioManager.instance.PlayBossBgm(true);
        BossSpawned = true;
        MapSpawner.SetActive(false);
        enemyCleaner.SetActive(true);
        yield return new WaitForSeconds(0.5f); //enemyCleaner로 필드에 생성된 몬스터들을 없애는 과정을 기다리는 시간
        enemyCleaner.SetActive(false);
        BossHP.SetActive(true);
        Vector3 newPosition = new Vector3(0f, GameManager.instance.player.transform.position.y + 12f, 0f);
        BossObj.transform.position = newPosition;
        BossObj.SetActive(true);
        BossUi.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        BossUi.SetActive(false);
    }
    IEnumerator LimitBossappearance()
    {
        AudioManager.instance.PlayBgm(false);
        AudioManager.instance.PlayBossBgm(true);
        BossSpawned = true;
        MapSpawner.SetActive(false);
        enemyCleaner.SetActive(true);
        yield return new WaitForSeconds(0.5f); //enemyCleaner로 필드에 생성된 몬스터들을 없애는 과정을 기다리는 시간
        enemyCleaner.SetActive(false);
        BossHP.SetActive(true);
        BossObj.transform.position = Vector3.zero;
        BossObj.SetActive(true);
        BossUi.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        BossUi.SetActive(false);
    }
    public void GameVictory()
    {
        StartCoroutine(GameVictoryRoutine());
    }
    // 딜레이를 위해 게임오버 코루틴도 작성
    IEnumerator GameVictoryRoutine() //보스 몬스터를 잡아서 게임이 끝남
    {
        isLive = false; 
        AudioManager.instance.PlayBgm(false);
        AudioManager.instance.PlayBossBgm(false);

        uiResult.gameObject.SetActive(true);
        uiResult.Win();
        Leaderboard.SetActive(true);

        yield return new WaitForSeconds(1.2f);
        Stop();

        AudioManager.instance.PlayBgm(false);
        AudioManager.instance.PlayBossBgm(false);
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Win);
    }
    void Update()
    {
        if (!isLive) //각 스크립트의 Update 계열 로직에 조건 추가하기
            return;

        // deltaTime 한 프레임이 소비한 시간
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime&&!BossSpawned) // 타이머가 일정 시간 값에 도달하면 소환하도록 작성
        {
            gameTime = maxGameTime;
            BossStage();
        }
    }

    public void GetExp()
    {
        if (!isLive||BossSpawned)
            return;

        exp++;

        if (exp == nextExp[Mathf.Min(level,nextExp.Length-1)]) //Mathf.Min = 둘 중에 작은 값만 나오게 된다. 즉, nextExp.Length = 10 에서 1을 빼면 9
                                                               // 9까지는 왼쪽 레벨이 더 낮아서 해당 레벨에 맞는 경험치가 다음 경험치가 되지만
                                                               // 9를 초과한 레벨부터는 오른쪽 레벨이 더 낮아서 9레벨에 설정된 경험치로 다음 경험치가 세팅된다.
        {
            level++;
            exp = 0;
            uiLevelUp.Show();
        }
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0; //timeScale : 유니티의 시간 속도(배율) 0=시간이 멈춤
    }
    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1; //timeScale : 1은 정상 속도
    }
}
