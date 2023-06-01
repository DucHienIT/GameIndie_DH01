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

    [SerializeField] protected EnemySO enemySO;
    public EnemySO EnemySO { get { return enemySO; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDamageReceiver();
        this.LoadEnemyDespawn();
        this.LoadEnemySO();


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

    protected virtual void LoadEnemyDespawn()
    {
        if (this.enemyDespawn != null) return;
        this.enemyDespawn = GetComponentInChildren<EnemyDespawn>();
    }
    protected virtual void LoadEnemySO()
    {
        if(this.enemySO != null) return;
        string path = "Enemy/" + transform.name;
        this.enemySO = Resources.Load<EnemySO>(path);
    }    
}
