using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleButton : BaseButton
{
    private int indexItemRecycle;

    protected override void OnClick()
    {
        LoadIndexItemRecycle();
        Equipment.Instance.RemoveItem(indexItemRecycle);
    }

    protected virtual void LoadIndexItemRecycle()
    {
        this.indexItemRecycle = this.transform.parent.parent.GetSiblingIndex();
    }

}
