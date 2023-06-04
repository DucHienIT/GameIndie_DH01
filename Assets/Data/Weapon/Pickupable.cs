using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Pickupable : DucHienMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected WeaponCtrl weaponCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadWeaponCtrl();
    }
    protected virtual void LoadWeaponCtrl()
    {
        if(this.weaponCtrl != null) return;
        this.weaponCtrl = transform.parent.GetComponent<WeaponCtrl>();
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
        this.weaponCtrl.WeaponDespawn.DespawnObject();
    }
}
