using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Status : DucHienMonoBehaviour
{
    [SerializeField] protected int health = 100;
    [SerializeField] protected int attackPower = 4;
    [SerializeField] protected int movementSpeed = 5;
    [SerializeField] protected int attackSpeed = 1;
    [SerializeField] protected int def = 1;

    

    protected abstract void UpdateStatus();


    protected virtual void FixedUpdate()
    {
        UpdateStatus();
    }

    
}