using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRandom : DucHienMonoBehaviour
{
    [Header("Enemy Despawn Random")]

    [SerializeField] protected EnemySpawnCtrl enemySpawnCtrl;
    [SerializeField] protected float enemySpawnDelay = 3f;
    [SerializeField] protected float enemySpawnTimer = 0f;
    [SerializeField] protected int enemySpawnLimit = 9;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawnCtrl();
    }
    protected virtual void LoadEnemySpawnCtrl()
    {
        if (this.enemySpawnCtrl != null) return;
        this.enemySpawnCtrl = this.GetComponent<EnemySpawnCtrl>();
        Debug.Log(transform.name + " load EnemySpawnCtrl", gameObject);
    }

    protected override void Start()
    {
        
    }
    protected virtual void FixedUpdate()
    {
        this.EnemySpawning();
    }
    protected virtual void EnemySpawning()
    {
        if (this.RandomReachLimit()) return;

        this.enemySpawnTimer += Time.fixedDeltaTime;
        if (this.enemySpawnTimer < this.enemySpawnDelay) return;
        this.enemySpawnTimer = 0f;

        Transform prefab = this.enemySpawnCtrl.EnemySpawner.RandomPrefab();


        Transform randomPoint = this.enemySpawnCtrl.EnemySpawnPoints.GetRandomPoint();
        Vector3 pos = randomPoint.position;
        Transform obj = this.enemySpawnCtrl.EnemySpawner.Spawn(prefab, pos, transform.rotation);
        obj.gameObject.SetActive(true);
    }
    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.enemySpawnCtrl.EnemySpawner.SpawnedCount;

        return currentJunk >= this.enemySpawnLimit;
    }
}
