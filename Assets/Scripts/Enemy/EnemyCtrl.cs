using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : DucHienMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get { return model; } }

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver { get { return damageReceiver; } }

    [SerializeField] protected EnemyDespawn enemyDespawn;
    public EnemyDespawn EnemyDespawn { get => enemyDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDamageReceiver();
        this.LoadJunkDespawn();


    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log("LoadModel: " + this.model);
    }
    
    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponentInChildren<DamageReceiver>();
        Debug.Log("LoadDamageReceiver: " + this.damageReceiver);
    }

    protected virtual void LoadJunkDespawn()
    {
        if (this.enemyDespawn != null) return;
        this.enemyDespawn = GetComponentInChildren<EnemyDespawn>();
    }

}
