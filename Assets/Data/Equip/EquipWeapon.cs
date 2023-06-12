using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class EquipWeapon : DucHienMonoBehaviour
{
    private static EquipWeapon instance;
    public static EquipWeapon Instance { get { return instance; } }
    [SerializeField] protected Inventory inventory;

    protected override void Awake()
    {
        base.Awake();
        if (EquipWeapon.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        EquipWeapon.instance = this;
    } 
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponentInChildren<Inventory>();
    }

    public virtual void EquipWeaponInInventory(Transform holder)
    {
        int index = 0;
        while(holder.childCount > 0)
        {
            holder.GetChild(0).SetParent(this.transform.GetChild(index));
            Debug.Log(index);
            index++;
        }
    }


}
