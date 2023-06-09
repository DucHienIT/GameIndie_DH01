using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    [SerializeField] protected CharaterStatus charaterStatus;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
        this.LoadCharaterStatus();

    }

    protected virtual void FixedUpdate()
    {
        this.UpdateDamage();
    }
    protected virtual void LoadCharaterStatus()
    {
        if (this.charaterStatus != null) return;
        this.charaterStatus = PlayerCtrl.Instance.Charater.GetComponent<CharaterStatus>();

    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }

    protected virtual void UpdateDamage()
    {
        if (!this.bulletCtrl.ShooterIsPlayer) return;
        this.damage = this.charaterStatus.AttackPower;

    }
    public override void Send(DamageReceiver receiver)
    {
        if (receiver.transform.parent.name == this.bulletCtrl.Shooter.name) return;

        base.Send(receiver);
        this.DestroyBullet();
    }
    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
}
