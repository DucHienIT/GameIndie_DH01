using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 30f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected Transform mainCamera;

    protected override void LoadComponents()
    {
        this.LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = Transform.FindObjectOfType<Camera>().transform;
        Debug.Log(transform.parent.name + " has no camera");
    }

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(this.transform.position, this.mainCamera.transform.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }
}
