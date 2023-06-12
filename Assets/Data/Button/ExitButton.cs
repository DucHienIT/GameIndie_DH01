using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : BaseButton
{
    protected override void OnClick()
    {
        PlayerCtrl.Instance.Charater.EquipWeapon.EquipWeaponInInventory(EquipSpawner.Instance.Holder);
        if (InventoryManager.Instance.IsOpen)
            InventoryManager.Instance.Toggle();
    }
}
