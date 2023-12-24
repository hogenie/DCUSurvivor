using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    // �ڽ� ������Ʈ�� Ʈ�������� ���� �迭 ���� ����
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
        enemy.transform.position = spawnPoint[1].position; //�ڽ� ������Ʈ�� ���õǵ��� ���� ������ 1 ����
        enemy.GetComponent<Enemy>().Init(BossSpawnData[0]);
    }
} 
[System.Serializable]
public class BossSpawnData
{
    public int health;
    public float speed;
}