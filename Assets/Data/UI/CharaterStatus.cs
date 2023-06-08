using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterStatus : Status
{
    private static CharaterStatus instance;
    public static CharaterStatus Instance { get { return instance; } }

    [SerializeField] protected Inventory inventory;
    [SerializeField] protected CharaterSO charaterSO;
    [SerializeField] protected int charaterLevel = 1;
    [SerializeField] protected int exp = 0;
    public CharaterSO CharaterSO { get { return charaterSO; } }

    public int Health => health;
    public int AttackPower => attackPower;

    protected override void Awake()
    {
        base.Awake();
        CharaterStatus.instance = this;
    }
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

        this.LoadCharaterStatus();
    }
    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = GetComponentInChildren<Inventory>();
    }
    protected override void UpdateStatus()
    {
        this.UpdateLevel();
    }

    protected virtual void UpdateLevel()
    {
        this.charaterLevel = CharaterLevelManager.Instance.CurrentLevelIndex;
        this.exp = CharaterLevelManager.Instance.CurrentExp;
    }

    public virtual void CalculateStatus(AttributeCode attributeCode, int value)
    {
        if(attributeCode == AttributeCode.Atk)
        {
            this.attackPower += value;
        }
        else if(attributeCode == AttributeCode.Def)
        {
            this.def += value;
        }
        else if(attributeCode == AttributeCode.Hp)
        {
            this.health += value;
        }
        else if(attributeCode == AttributeCode.SpeedAtk)
        {
            this.attackSpeed += value;
        }   
    }
    
    protected virtual void LoadCharaterStatus()
    {
        this.health = this.charaterSO.hpMax;
        this.attackPower = this.charaterSO.atk;
        this.movementSpeed = this.charaterSO.spd;
        this.attackSpeed = this.charaterSO.atkSpd;
        this.def = this.charaterSO.def;
    }
}
