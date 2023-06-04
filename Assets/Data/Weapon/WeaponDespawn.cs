using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDespawn : DespawnByLoot
{
    public override void DespawnObject()
    {
        WeaponSpawner.Instance.Despawn(transform.parent);
    }
}
