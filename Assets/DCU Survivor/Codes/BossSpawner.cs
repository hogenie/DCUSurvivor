using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    // 자식 오브젝트의 트랜스폼을 담을 배열 변수 선언
    public Transform[] spawnPoint;
    public BossSpawnData[] BossSpawnData;
    public GameObject emptyObjectPrefab;
    public Transform parentTransform;

    public static BossSpawner instance;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Vector3 newPosition = new Vector3(0f, GameManager.instance.player.transform.position.y + 10f, 0f);
        GameObject childObject = Instantiate(emptyObjectPrefab, newPosition, Quaternion.identity, parentTransform);
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    public void BossSpawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[1].position; //자식 오브젝트만 선택되도록 랜덤 시작은 1 부터
        enemy.GetComponent<Enemy>().Init(BossSpawnData[0]);
    }
} 
[System.Serializable]
public class BossSpawnData
{
    public int health;
    public float speed;
}