using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterStatus : Status
{
    [SerializeField] protected Inventory inventory;

    public int Health => health;
    public int AttackPower => attackPower;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        inventory = GetComponentInChildren<Inventory>();
    }
    protected override void UpdateStatus()
    {
        this.CalculateStatus();
    }

    protected virtual void CalculateStatus()
    {
        int hp = 100;
        int atk = 10;
        foreach (ItemInventory item in inventory.ListWeapons)
        {
            hp += item.weaponSO.hp * item.itemCount;
            atk += item.weaponSO.atk * item.itemCount;
        }
        this.health = hp;
        this.attackPower = atk;
    }

}
