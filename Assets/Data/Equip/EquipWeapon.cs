using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class EquipWeapon : DucHienMonoBehaviour
{
    private static EquipWeapon instance;
    public static EquipWeapon Instance { get { return instance; } }
    [SerializeField] protected Inventory inventory;

    [SerializeField] protected List<Transform> holder;
    public List<Transform> Holder => holder;

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
    public virtual void LoadHolder()
    {
        int index = 0;
        while (true)
        {
            if (this.transform.GetChild(index).childCount > 0)
                this.holder.Add(this.transform.GetChild(index).GetChild(0));
            index++;

            if (index >= 6) return;
        }
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponentInChildren<Inventory>();
    }

    public virtual void AddEquip(WeaponSO weapon)
    {
        Transform obj = EquipSpawner.Instance.Spawn(weapon.name, transform.position, transform.rotation);
        if (obj == null) return;
        obj.gameObject.SetActive(true);

        int index = 0;
        while (index < 6)
        {
            if (this.transform.GetChild(index).childCount == 0)
            {
                obj.SetParent(this.transform.GetChild(index));
                this.holder.Add(obj);
                return;
            }
            index++;
        }
      
    }

    protected virtual Transform ResetLocalScale(Transform item)
    {
        item.localScale = new Vector3(0.3f, 0.3f, 1f);
        return item;
    }

    public virtual void RemoveEquip(int index)
    {
        Transform removeEquip = this.transform.GetChild(index).GetChild(0);
        if (removeEquip == null) return;
        this.holder.Remove(removeEquip);
        Destroy(removeEquip.gameObject);
    }
}
