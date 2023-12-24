using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeSpawner : MonoBehaviour
{
    public GameObject SpawnObject;
    //public GameObject BossSpawnObject;

    private void Start()
    {
        GameManager.instance.MapSpawner = SpawnObject;
        //GameManager.instance.BossSpawnerobj = BossSpawnObject;
    }
}
