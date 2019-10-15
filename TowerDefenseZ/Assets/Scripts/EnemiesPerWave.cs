using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemiesPerWave {

    public GameObject enemy;
    public int count;

    public EnemiesPerWave(GameObject enemy, int count, bool isInfinity)
    {
        if (isInfinity)
        {
            this.enemy = enemy;
            this.count = count;
        }

    }
}
