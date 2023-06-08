using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttributeItemButton : BaseButton
{
    [SerializeField] protected AttributeItemCtrl attributeItemCtrl;
    public AttributeItemCtrl AttributeItemCtrl => attributeItemCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttributeItemCtrl();
    }
    protected virtual void LoadAttributeItemCtrl()
    {
        if (this.attributeItemCtrl != null) return;
        this.attributeItemCtrl = transform.parent.GetComponent<AttributeItemCtrl>();
    }
    protected override void OnClick()
    {
        GameCtrl.Instance.ResumeGame();
        CharaterStatus.Instance.CalculateStatus(this.attributeItemCtrl.AttributeItemSO.attributeCode, this.attributeItemCtrl.AttributeItemSO.value);
        AttributeTableUI.Instance.Toggle();
    }
}
