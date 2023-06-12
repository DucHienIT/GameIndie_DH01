using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterCtrl : DucHienMonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    [SerializeField] protected EquipWeapon equipWeapon;
    public EquipWeapon EquipWeapon => equipWeapon;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        this.LoadEquipWeapon();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInChildren<Inventory>();
    }
    protected virtual void LoadEquipWeapon()
    {
        if (this.equipWeapon != null) return;
        this.equipWeapon = GetComponentInChildren<EquipWeapon>();
    }
}
