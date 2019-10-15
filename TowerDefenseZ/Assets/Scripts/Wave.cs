using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave{

    public EnemiesPerWave[] enemies;

    public bool shuffleBefore;
    public int killNodes;

    //private GameObject[] spawnList = new GameObject[]();
    private List<GameObject> spawnList = new List<GameObject>();
    private int enemyCounter = 0;

    
    public void Startactually()
    {
        Debug.Log("Here");
        foreach(EnemiesPerWave entry in enemies){
            for(int i = 0; i<=entry.count; i++)
            {
                spawnList.Add(entry.enemy);
            }
        }
    }

    public float rate;
    public GameObject getNextEnemy()
    {
        GameObject ret =  spawnList[enemyCounter];
        enemyCounter++;
        return ret;
    }
    public int count()
    {
        // number of total enemies
        return spawnList.Count;
    }
    public Wave(float rate, bool shuffleBefore, int killNodes, EnemiesPerWave[] wave1, bool isInfinity)
    {
        /*
        isInfinity = false;
        if (isInfinity)
        {
            Debug.Log("const");
            this.rate = rate;
            this.shuffleBefore = shuffleBefore;
            this.killNodes = killNodes;
            //this.enemies = null;
            this.enemies = wave1;

            Debug.Log(enemies.Length);
            //this.Startactually();
        }
        else
        {
        */
        Debug.Log("Startactually");
        //this.Startactually();
        //}


    }
    public string toString()
    {
        return ("Wave: Enemies Array" + enemies.Length );
    }
}
