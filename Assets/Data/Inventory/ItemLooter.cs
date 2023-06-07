using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class ItemLooter : DucHienMonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        this.LoadSphereCollider();
        this.LoadRigidbody();

    }
    protected virtual void LoadInventory()
    {
        if(this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
    }
    protected virtual void LoadSphereCollider()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.radius = 0.2f;
    }
    protected virtual void LoadRigidbody()
    {
        if(this.rigidbody != null) return;
        this.rigidbody = transform.GetComponent<Rigidbody>();
        this.rigidbody.useGravity = false;
        this.rigidbody.isKinematic = true;
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        Pickupable pickupable = other.GetComponent<Pickupable>();
        if(pickupable == null) return;
        Transform weapon = other.transform.parent;
        if(LootCoin(weapon)) return;

        ItemInventory item = new ItemInventory();
        item.weaponSO = weapon.GetComponent<WeaponCtrl>().WeaponSO;
        item.itemCount = 1;
        inventory.AddItem(item);
    }

    protected virtual bool LootCoin(Transform item)
    {
        if(item.name == "Coin")
        {
            inventory.AddCoin(item.GetComponent<CoinCtrl>().CoinValue);
            return true;
        }
        return false;
    }
}
