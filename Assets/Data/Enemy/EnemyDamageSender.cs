using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.UpdateDamage();

    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadenemyCtrl", gameObject);
    }

    protected virtual void UpdateDamage()
    {
        this.damage = this.enemyCtrl.EnemySO.damage;
    }
    public override void Send(DamageReceiver receiver)
    {
        if (receiver.transform.parent.name == this.transform.parent.name) return;
        base.Send(receiver);
    }
}
