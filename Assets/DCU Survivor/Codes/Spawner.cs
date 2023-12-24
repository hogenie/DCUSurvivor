using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // �ڽ� ������Ʈ�� Ʈ�������� ���� �迭 ���� ����
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

        // deltaTime �� �������� �Һ��� �ð�
        timer += Time.deltaTime;
        // FloorToInt : �Ҽ��� �Ʒ��� ������ int������ �ٲٴ� �Լ�, CeilToInt : �Ҽ��� �Ʒ��� �ø��� int������ �ٲٴ� �Լ�
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f), spawnData.Length - 1);


        if (timer > spawnData[level].spawnTime) // Ÿ�̸Ӱ� ���� �ð� ���� �����ϸ� ��ȯ�ϵ��� �ۼ�
        {
            timer = 0f;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position; //�ڽ� ������Ʈ�� ���õǵ��� ���� ������ 1 ����
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