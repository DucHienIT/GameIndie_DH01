using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : Spawner
{
    private static WeaponSpawner instance;
    public static WeaponSpawner Instance { get { return instance; } }

    [Header("List")]
    [SerializeField] public List<Transform> ItemList;

    [Header("AttributeItemSpawner")]
    [SerializeField] protected StoreTableCtrl storeTableCtrl;
    public StoreTableCtrl StoreTableCtrl { get { return this.storeTableCtrl; } }

    protected override void Awake()
    {
        base.Awake();
        if (WeaponSpawner.instance != null) Debug.LogError("There are more than one WeaponSpawner in the scene!");
        WeaponSpawner.instance = this;
    }
    protected override void LoadHolder()
    {
        this.LoadAttributeUICtrl();
        if (this.holder != null) return;
        this.holder = this.storeTableCtrl.Content;
        Debug.Log("holder: " + this.holder);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListItem();
    }
    protected virtual void LoadAttributeUICtrl()
    {
        if (this.storeTableCtrl != null) return;
        this.storeTableCtrl = transform.parent.GetComponent<StoreTableCtrl>();
    }
    protected virtual void LoadListItem()
    {
        if (this.ItemList.Count > 0) return;
        Transform prefabObj = this.transform.Find("Prefabs");
        foreach (Transform child in prefabObj)
        {
            ItemList.Add(child);
        }
    }

}
