using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : DucHienMonoBehaviour
{
    [SerializeField] protected int health = 100;
    [SerializeField] protected int attackPower = 10;
    [SerializeField] protected float movementSpeed = 5f;

    protected abstract void UpdateStatus();


    protected virtual void FixedUpdate()
    {
        UpdateStatus();
    }

    
}