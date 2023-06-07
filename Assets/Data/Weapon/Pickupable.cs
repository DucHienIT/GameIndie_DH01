using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Pickupable : DucHienMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected CoinCtrl coinCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadWeaponCtrl();
    }
    protected virtual void LoadWeaponCtrl()
    {
        if(this.coinCtrl != null) return;
        this.coinCtrl = transform.parent.GetComponent<CoinCtrl>();
    }
    protected virtual void LoadSphereCollider()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.1f;
        Debug.LogWarning(transform.name + "LoadTrigger", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        ItemLooter itemLooter = other.GetComponent<ItemLooter>();
        if (itemLooter == null) return;
        this.coinCtrl.CoinDespawn.DespawnObject();
    }
}
