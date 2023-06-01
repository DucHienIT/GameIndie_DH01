using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : DucHienMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;


    protected virtual void Update()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (this.target == null) return;
        transform.position = new Vector3(this.target.position.x, this.target.position.y, -10f);
    }
}
