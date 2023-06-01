using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : DucHienMonoBehaviour
{
    [SerializeField] protected List<Transform> spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }
    protected virtual void LoadSpawnPoints()
    {
        if (this.spawnPoints.Count > 0) return;
        foreach (Transform child in transform)
        {
            this.spawnPoints.Add(child);
        }
    }
    public virtual Transform GetRandomPoint()
    {
        int randomIndex = Random.Range(0, this.spawnPoints.Count);
        return this.spawnPoints[randomIndex];
    }
}
