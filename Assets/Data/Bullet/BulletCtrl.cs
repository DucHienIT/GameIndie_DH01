using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : DucHienMonoBehaviour
{
    [SerializeField] protected BulletDamageSender damageSender;
    public BulletDamageSender DamageSender { get { return damageSender; } }

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn { get => bulletDespawn; }

    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
    }
    protected virtual void LoadDamageSender()
    {
        if (this.damageSender != null) return;
        this.damageSender = GetComponentInChildren<BulletDamageSender>();
        Debug.Log("DamageSender: " + this.damageSender);
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = GetComponentInChildren<BulletDespawn>();
        Debug.Log("BulletDespawn: " + this.bulletDespawn);
    }

    public virtual void SetShooter(Transform shooterSet)
    {
        this.shooter = shooterSet;
    }
}
