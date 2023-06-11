using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : DucHienMonoBehaviour
{
    private static Inventory instance;
    public static Inventory Instance { get { return instance; } }

    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> weapons;
    [SerializeField] protected int totelCoin = 0;
    public int TotelCoin => totelCoin;
    public List<ItemInventory> ListWeapons => weapons;

    protected override void Awake()
    {
        base.Awake();
        if (Inventory.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Inventory.instance = this;
    }
    public virtual bool AddItem(ItemInventory item)
    {
        if (this.weapons.Count >= this.maxSlot) return false;
        if (checkItemInInventory(item)) return false;
        this.weapons.Add(item);

        return true;
    }
    public virtual void AddCoin(int coin)
    {
        this.totelCoin += coin;
    }
    public virtual bool checkItemInInventory(ItemInventory itemInventory)
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
