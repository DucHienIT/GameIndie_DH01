using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : DucHienMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> weapons;
    [SerializeField] protected int totelCoin = 0;

    public List<ItemInventory> ListWeapons => weapons;


    public virtual bool AddItem(ItemInventory item)
    {
        if (this.weapons.Count >= this.maxSlot) return false;
        if (checkItemInInventory(item)) return true;
        this.weapons.Add(item);
        return true;   
    }
    public virtual void AddCoin(int coin)
    {
        this.totelCoin += coin;
    }
    protected virtual bool checkItemInInventory(ItemInventory itemInventory)
    {
        foreach (ItemInventory item in this.weapons)
        {
            if (itemInventory.weaponSO.name == item.weaponSO.name)
            {
                item.itemCount += itemInventory.itemCount;
                return true;
            }
        }
        return false;
    }

    public virtual void EquipWeapon(WeaponSO weapon)
    {
        
    }
}
