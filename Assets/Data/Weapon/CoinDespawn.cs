using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDespawn : DespawnByLoot
{
    public override void DespawnObject()
    {
        CoinSpawner.Instance.Despawn(transform.parent);
    }
}
