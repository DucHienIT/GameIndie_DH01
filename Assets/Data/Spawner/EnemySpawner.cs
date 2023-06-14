using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get { return instance; } }

    public static string Enemy_1 = "Enemy_1";
    public static string Enemy_2 = "Enemy_2";

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.LogError("There are more than one EnemySpawner in the scene!");
        EnemySpawner.instance = this;
    }

    public override Transform RandomPrefab()
    {
        int rand = 0;
        float rate = 0f;
        while(true)
        {
            rand = Random.Range(0, this.prefabs.Count);
            rate = this.prefabs[rand].GetComponent<EnemyCtrl>().EnemySO.rateEachRound[RoundManager.Instance.RoundCount - 1];
            if (rate == null) rate = 0;
            if (SpawnRate(rate)) return this.prefabs[rand];
        }    
    }

    protected virtual bool SpawnRate(float itemSpawnRate)
    {
        float randomValue = Random.Range(0, 1f);
        if (randomValue <= itemSpawnRate)
        {
            return true; // Spawn
        }
        else
        {
            return false; // Don't spawn
        }
    }
}
