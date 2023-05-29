using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterPunch : DucHienMonoBehaviour
{
    [SerializeField] protected bool punch = false;
    private Animator animator;
    protected override void Start()
    {
        animator = transform.parent.GetComponentInChildren<Animator>();
    }
    void Update()
    {
        this.SetPunch();
        this.Punch();
    }

    void FixedUpdate()
    {
        //this.Punch();
    }
    protected virtual void Punch()
    {
        animator.SetBool("isPunch", this.punch);
    }
    protected virtual void SetPunch()
    {
        this.punch = InputManager.Instance.OnFiring == 1;
        
    }
}
