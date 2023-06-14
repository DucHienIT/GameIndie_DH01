using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCtrl : DucHienMonoBehaviour
{
    private static InventoryCtrl instance;
    public static InventoryCtrl Instance { get { return instance; } }

    [SerializeField] protected Transform content;
    public Transform Content { get { return this.content; } }

    [SerializeField] protected Inventory inventory;
    public Inventory Inventory { get { return this.inventory; } }

    protected override void Awake()
    {
        base.Awake();
        if (InventoryCtrl.instance != null)
            Debug.LogError("InventoryCtrl is already in the scene");
        InventoryCtrl.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadInventory();
    }
    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
    }
    protected virtual void LoadInventory()
    {
        if (PlayerCtrl.Instance == null) return;
        this.inventory = PlayerCtrl.Instance.Charater.Inventory;

    }

    public virtual bool AddItem(Transform item)
    {
        if (!CheckEnoughCoin(item)) return false;
        this.AddItemIntoInventory(item);

        
        if (CheckItemInInventory(item)) return true;
        Transform newTransform = Instantiate(item);
        this.TurnOffButton(newTransform);
        newTransform.localScale = new Vector3(0.2f, 0.2f, 1);
        newTransform.parent = this.content;

        return true;
    }   
    protected virtual void AddItemIntoInventory(Transform item)
    {
        WeaponSO weaponSO = item.GetComponent<WeaponCtrl>().WeaponSO;
        ItemInventory itemInventory = new ItemInventory(weaponSO, 1);
        this.inventory.AddItem(itemInventory);
        this.CalculateExtraAttributeWeapon(weaponSO);
        this.SaveInventory(); //Test save inventory
    }    

    protected virtual bool CheckItemInInventory(Transform item)
    {
        foreach (Transform child in this.content)
        {
            if (child.GetComponentInChildren<WeaponCtrl>().WeaponSO.name == item.GetComponentInChildren<WeaponCtrl>().WeaponSO.name)
            {
                this.AddNumberItemText(child);
                return true;
            }
        }
        return false;
    }
    protected virtual void TurnOffButton(Transform parent)
    {
        Button button = parent.GetComponentInChildren<Button>();
        GameObject text = parent.Find("Price").gameObject;
        button.enabled = false;
        text.SetActive(false);
    }    

    protected virtual void AddNumberItemText(Transform parent)
    {
        Text text = parent.GetComponentInChildren<Text>();
        foreach (ItemInventory item in this.inventory.ListWeapons)
        {
            if (parent.GetComponentInChildren<WeaponCtrl>().WeaponSO.name == item.weaponSO.name)
            {
                text.text = "x" + item.itemCount.ToString();
                return;
            }
        }
    }

    protected virtual void SaveInventory()
    {
        List<string> nameItem = new List<string>();
        List<int> amoutItem = new List<int>();
        foreach (ItemInventory item in this.inventory.ListWeapons)
        {
            nameItem.Add(item.weaponSO.name);
            amoutItem.Add(item.itemCount);
        }

        InventoryData inventoryData = new InventoryData(nameItem, amoutItem);

        string json = JsonUtility.ToJson(inventoryData);

        PlayerPrefs.SetString("Inventory", json);

    }

    protected virtual void CalculateExtraAttributeWeapon(WeaponSO weapon)
    {
        if (PlayerCtrl.Instance == null) return;
        foreach (Attribute attribute in weapon.Attribute)
        {
            PlayerCtrl.Instance.Status.CalculateStatus(attribute.attributeCode, attribute.value);
        }
    }

    protected virtual bool CheckEnoughCoin(Transform item)
    {
        WeaponSO weaponSO = item.GetComponent<WeaponCtrl>().WeaponSO;
        if (this.inventory.TotelCoin < weaponSO.price) return false;
        
        PlayerCtrl.Instance.Charater.Inventory.AddCoin(-weaponSO.price);
        return true;

    }
}
