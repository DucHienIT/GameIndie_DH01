using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseButton : BaseButton
{
    protected override void OnClick()
    {
        if (!InventoryCtrl.Instance.AddItem(this.transform.parent)) return;
        StoreTableRandom.Instance.DespawnItemPick(this.transform.parent);
    }
}
