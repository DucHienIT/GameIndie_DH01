using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAbstract : DucHienMonoBehaviour
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl { get { return bulletCtrl; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log("LoadBulletCtrl: " + this.bulletCtrl);
    }
}
