using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseButton : BaseButton
{
    protected override void OnClick()
    {
        if (StoreTableRandom.Instance.CheckIsEquipment(this.transform.parent))
        {
            if (!Equipment.Instance.AddItem(this.transform.parent)) return;
            Debug.Log("Add Equip");
        }
        else
        {
            if (!InventoryCtrl.Instance.AddItem(this.transform.parent)) return;
            Debug.Log("Add Item Inventory");

        }
        DisplayCoin.Instance.UpdateLevelText();
        StoreTableRandom.Instance.DespawnItemPick(this.transform.parent);
    }
}
