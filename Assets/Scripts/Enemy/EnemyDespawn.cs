using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
