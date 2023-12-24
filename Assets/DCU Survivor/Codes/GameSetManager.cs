using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetManager : MonoBehaviour
{
    void Update()
    {
        if (Enemy.instance.health <= 0)
        {
            GameManager.instance.GameVictory();
        }
    }
}
