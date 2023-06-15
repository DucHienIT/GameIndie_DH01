using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Equipment : DucHienMonoBehaviour
{
    private static Equipment instance;
    public static Equipment Instance { get { return instance; } }

    [SerializeField] protected Transform content;
    public Transform Content { get { return this.content; } }

    [SerializeField] protected EquipWeapon equipWeapon;
    public EquipWeapon EquipWeapon { get { return this.equipWeapon; } }

    protected override void Awake()
    {
        base.Awake();
        if (Equipment.instance != null)
            Debug.LogError("Equipment is already in the scene");
        Equipment.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        this.ReloadWeaponInEquipment();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadEquipWeapon();
    }
    protected virtual void LoadEquipWeapon()
    {
        if (PlayerCtrl.Instance == null) return;
        this.equipWeapon = PlayerCtrl.Instance.Charater.EquipWeapon;
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
    }

    public virtual bool AddItem(Transform item)
    {
        if (!CheckEnoughCoin(item)) return false;
        if (!CheckCanAddItem(item)) return false;

        this.equipWeapon.AddEquip(item.GetComponent<WeaponCtrl>().WeaponSO);
        
        Transform newTransform = Instantiate(item);
        this.TurnOffChooseButton(newTransform);
        this.TurnOnHoverBlock(newTransform);
        newTransform.localScale = new Vector3(0.3f, 0.3f, 1);
        newTransform.parent = this.content;

        return true;
    }
    public virtual void RemoveItem(int index)
    {
        Debug.Log("RemoveItem: " + index);
        this.equipWeapon.RemoveEquip(index);
        Destroy(this.content.GetChild(index).gameObject);
        this.ReloadWeaponInEquipment();
    }

    protected virtual void TurnOffChooseButton(Transform parent)
    {
        Button button = parent.GetComponentInChildren<Button>();
        GameObject text = parent.Find("Price").gameObject;
        
        button.enabled = false;
        text.SetActive(false);
    }
    protected virtual void TurnOnHoverBlock(Transform item)
    {
        item.Find("Hover").gameObject.SetActive(true);
    }

    protected virtual bool CheckEnoughCoin(Transform item)
    {
        WeaponSO weaponSO = item.GetComponent<WeaponCtrl>().WeaponSO;
        if (PlayerCtrl.Instance.Charater.Inventory.TotelCoin < weaponSO.price) return false;

        PlayerCtrl.Instance.Charater.Inventory.AddCoin(-weaponSO.price);
        return true;
    }

    protected virtual void ReloadWeaponInEquipment()
    {
        this.RemoveAllItem();
        List<Transform> transforms = PlayerCtrl.Instance.Charater.EquipWeapon.Holder;

        foreach (Transform item in transforms)
        {
            Transform newTransform = WeaponSpawner.Instance.Spawn(item.name, item.position, Quaternion.Euler(0, 0, 0));
            newTransform.gameObject.SetActive(true);
            newTransform.localScale = new Vector3(0.3f, 0.3f, 1);
            this.TurnOffChooseButton(newTransform);
            this.TurnOnHoverBlock(newTransform);
            newTransform.parent = this.content;
        }
    }
    protected virtual void RemoveAllItem()
    {
        for (int i = 0; i < this.content.childCount; i++)
        {
            Destroy(this.content.GetChild(i).gameObject);
        }
    }

    protected virtual bool CheckCanAddItem(Transform item)
    {
        if (this.content.childCount < 6) return true;
        return false;
    }       
}
