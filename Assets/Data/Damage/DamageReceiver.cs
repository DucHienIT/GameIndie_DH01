using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : DucHienMonoBehaviour
{
    [Header("Damage Receiver")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp = 10;


    public int Hp { get { return hp; } }

    [SerializeField] protected int maxHp = 10;
    public int MaxHp { get { return maxHp; } }


    [SerializeField] protected bool isDead = false;

    protected override void OnEnable()
    {
        this.Reborn();
    }

    public virtual void Reborn()
    {
        this.hp = this.maxHp;
        this.isDead = false;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.2f;
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    public virtual void Add(int value)
    {
        this.hp += value;
        if (this.hp > this.maxHp) this.hp = this.maxHp;
    }

    public virtual void Sub(int value)
    {
        if (this.isDead) return;
        this.hp -= value;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }
    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected abstract void OnDead();
}
