using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterStatus : Status
{
    [SerializeField] protected Inventory inventory;
    [SerializeField] protected CharaterSO charaterSO;
    [SerializeField] protected int charaterLevel = 1;
    [SerializeField] protected int exp = 0;
    public CharaterSO CharaterSO { get { return charaterSO; } }

    public int Health => health;
    public int AttackPower => attackPower;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySO();
        this.LoadInventory();
    }


    protected virtual void LoadEnemySO()
    {
        if (this.charaterSO != null) return;
        string path = "Charater/" + transform.name;
        this.charaterSO = Resources.Load<CharaterSO>(path);
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInChildren<Inventory>();
    }
    protected override void UpdateStatus()
    {
        this.CalculateStatus();
        this.UpdateLevel();
    }

    protected virtual void UpdateLevel()
    {
        this.charaterLevel = CharaterLevelManager.Instance.CurrentLevelIndex;
        this.exp = CharaterLevelManager.Instance.CurrentExp;
    }

    protected virtual void CalculateStatus()
    {
        int hp = charaterSO.hpMax; //sửa lại sau
        int atk = charaterSO.atk;
        foreach (ItemInventory item in inventory.ListWeapons)
        {
            hp += item.weaponSO.hp * item.itemCount;
            atk += item.weaponSO.atk * item.itemCount;
        }
        this.health = hp;
        this.attackPower = atk;
    }
}
