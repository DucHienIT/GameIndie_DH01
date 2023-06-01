using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : DucHienMonoBehaviour
{
    [SerializeField] protected int damage = 10;

    public virtual void Send(Transform obj)
    {
        DamageReceiver receiver = obj.GetComponentInChildren<DamageReceiver>();
        if (receiver == null) return;
        this.Send(receiver);
    }

    public virtual void Send(DamageReceiver receiver)
    {
        receiver.Sub(this.damage);
    }
}
