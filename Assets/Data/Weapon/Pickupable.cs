using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Pickupable : DucHienMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }
    protected virtual void LoadSphereCollider()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.1f;
        Debug.LogWarning(transform.name + "LoadTrigger", gameObject);
    }
}
