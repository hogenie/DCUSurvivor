using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPosition : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject monsterPrefab;
    public PolygonCollider2D spawnRangeCollider;

    public static SpawnPosition instance;

    private float cameraHeight;
    private float cameraWidth;

    void Awake()
    {
        instance = this; //�ڱ��ڽ� this�� �ʱ�ȭ    
    }
    private void Start()
    {
        Vector2 boundsSize = spawnRangeCollider.bounds.size;
        cameraHeight = 2f * mainCamera.orthographicSize;
        cameraWidth = cameraHeight * mainCamera.aspect;
    }
    public void SpawnPointPosition()
    {
        // �÷��̾��� ��ġ
        Vector3 playerPosition = transform.position;

        // ���� ��ȯ ��ġ ���
        float spawnX = Random.Range(spawnRangeCollider.bounds.min.x, spawnRangeCollider.bounds.max.x);
        float spawnY = Random.Range(spawnRangeCollider.bounds.min.y, spawnRangeCollider.bounds.max.y);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        if (!IsWithinSpawnRange(spawnPosition))
        {
            return;
        }

        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(spawnPosition);
        if (viewportPosition.x >= 0f && viewportPosition.x <= 1f && viewportPosition.y >= 0f && viewportPosition.y <= 1f)
        {
            return;
        }

        Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, 0.5f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Object") || collider.CompareTag("Wall"))
            {
                return;
            }
        }
    }
    private bool IsWithinSpawnRange(Vector3 position)
    {
        if (spawnRangeCollider != null)
        {
            Vector2 spawnRangeMin = spawnRangeCollider.bounds.min;
            Vector2 spawnRangeMax = spawnRangeCollider.bounds.max;

            spawnRangeMin = spawnRangeCollider.transform.TransformPoint(spawnRangeMin);
            spawnRangeMax = spawnRangeCollider.transform.TransformPoint(spawnRangeMax);

            return position.x > spawnRangeMin.x && position.x < spawnRangeMax.x &&
                   position.y > spawnRangeMin.y && position.y < spawnRangeMax.y;
        }

        // �ڽ� �ݶ��̴��� ���� ���, �׻� true ��ȯ
        return true;
    }
}