using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy")]
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();

        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }
    protected override void OnDead()
    {
        this.enemyCtrl.EnemyDespawn.DespawnObject();
    }
    protected virtual void OnDeadFX()
    {
       
    }
    public override void Reborn()
    {
       
        base.Reborn();
    }
}
