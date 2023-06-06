using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shoot : DucHienMonoBehaviour
{
    protected virtual void Update()
    {
        this.SetShooting();
    }
    protected virtual void FixedUpdate()
    {
        this.Shooting();
    }

    protected abstract void Shooting();

    protected abstract void SetShooting();

   
}
