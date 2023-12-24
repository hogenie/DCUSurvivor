using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 자식 오브젝트의 트랜스폼을 담을 배열 변수 선언
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;

    int level;
    float timer;

    void Start()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        // deltaTime 한 프레임이 소비한 시간
        timer += Time.deltaTime;
        // FloorToInt : 소수점 아래는 버리고 int형으로 바꾸는 함수, CeilToInt : 소수점 아래를 올리고 int형으로 바꾸는 함수
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1);


        if (timer > spawnData[level].spawnTime) // 타이머가 일정 시간 값에 도달하면 소환하도록 작성
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; //자식 오브젝트만 선택되도록 랜덤 시작은 1 부터
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
} 
[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}