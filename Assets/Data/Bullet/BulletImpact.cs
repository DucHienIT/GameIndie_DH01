using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigidbody;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
        
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.05f;
        Debug.Log("LoadSphereCollider: " + this.sphereCollider);
    }
    
    protected virtual void LoadRigidbody()
    {
        if (this.rigidbody != null) return;
        this.rigidbody = GetComponent<Rigidbody>();
        this.rigidbody.isKinematic = true;
        Debug.Log("LoadRigidbody: " + this.rigidbody);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
         
         this.BulletCtrl.DamageSender.Send(other.transform);  
    }
}
