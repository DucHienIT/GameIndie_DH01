using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttributeItemValue : DucHienMonoBehaviour
{
    [SerializeField] protected AttributeItemCtrl attributeItemCtrl;

    [SerializeField] protected int value;
    public int Value { get { return this.value; } }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttributeItemCtrl();
        this.LoadValue();
    }
    protected virtual void LoadAttributeItemCtrl()
    {
        if (this.attributeItemCtrl != null) return;
        this.attributeItemCtrl = transform.parent.GetComponent<AttributeItemCtrl>();
    }
    protected virtual void LoadValue()
    {
        AttributeItemSO attributeItemSO = this.attributeItemCtrl.AttributeItemSO;
        if (attributeItemSO == null) return;
        this.value = attributeItemSO.value;
    }

    public virtual void UpdateValue(int value)
    {
        this.value = value;
    }

}
