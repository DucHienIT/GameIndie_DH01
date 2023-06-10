using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseButton : BaseButton
{
    protected override void OnClick()
    {
        InventoryCtrl.Instance.AddItem(this.transform.parent);
    }
}
