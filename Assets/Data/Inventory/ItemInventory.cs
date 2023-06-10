using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemInventory
{
    public WeaponSO weaponSO;
    public int itemCount = 0;
    public int maxStack = 7;

    public ItemInventory(WeaponSO weaponSO, int itemCount)
    {
        this.weaponSO = weaponSO;
        this.itemCount = itemCount;
        
    }
}
