using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnCtrl : DucHienMonoBehaviour
{
    [SerializeField] protected EnemySpawner enemySpawner;
    [SerializeField] protected EnemySpawnPoints enemySpawnPoints;

    public EnemySpawner EnemySpawner { get { return enemySpawner; } }
    public EnemySpawnPoints EnemySpawnPoints { get { return enemySpawnPoints; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
        this.LoadEnemySpawnPoints();
    }
    protected virtual void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        this.enemySpawner = this.GetComponent<EnemySpawner>();
        Debug.Log(transform.name + " load EnemySpawner", gameObject);
    }

    protected virtual void LoadEnemySpawnPoints()
    {
        if (this.enemySpawnPoints != null) return;
        this.enemySpawnPoints = Transform.FindObjectOfType<EnemySpawnPoints>();
        Debug.Log(transform.name + " load enemySpawnPoints", gameObject);
    }
}
