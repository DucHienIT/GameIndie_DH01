using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeUICtrl : DucHienMonoBehaviour
{
    [SerializeField] protected Transform content;
    public Transform Content { get { return this.content; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
    }
    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
    }
}
