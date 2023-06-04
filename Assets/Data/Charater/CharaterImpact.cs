using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterImpact : DucHienMonoBehaviour
{
    private static CharaterImpact instance;
    public static CharaterImpact Instance { get { return instance; } }

    [SerializeField] protected bool onGround;
    public bool OnGround { get { return this.onGround; } }


    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected override void Awake()
    {
        if (CharaterImpact.instance != null)
        {
            Debug.LogError("There is more than one CharaterImpact in the scene!");
        }
        CharaterImpact.instance = this;
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        this.onGround = true;
    }

    public virtual void SetOnGroud(bool value)
    {
        this.onGround = value;
    }    
}
