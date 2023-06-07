using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeItemSpawner : Spawner
{
    private static AttributeItemSpawner instance;
    public static AttributeItemSpawner Instance { get { return instance; } }

    [Header("List")]
    [SerializeField] public List<Transform> ItemList;

    [Header("AttributeItemSpawner")]
    [SerializeField] protected AttributeUICtrl attributeUICtrl;
    public AttributeUICtrl AttributeUICtrl { get { return this.attributeUICtrl; } }


    protected override void Awake()
    {
        base.Awake();
        if (AttributeItemSpawner.instance != null) Debug.LogError("There are more than one AttributeItemSpawner in the scene!");
        AttributeItemSpawner.instance = this;
    }
    protected override void LoadHolder()
    {
        this.LoadAttributeUICtrl();
        if (this.holder != null) return;
        this.holder = this.attributeUICtrl.Content;
        Debug.Log("holder: " + this.holder);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListItem();
    }
    protected virtual void LoadAttributeUICtrl()
    {
        if (this.attributeUICtrl != null) return;
        this.attributeUICtrl = transform.parent.GetComponent<AttributeUICtrl>();
    }
    protected virtual void LoadListItem()
    {
        if (this.ItemList.Count > 0) return;
        Transform prefabObj = this.transform.Find("Prefabs");
        Debug.Log("prefabObj: " + prefabObj);
        foreach (Transform child in prefabObj)
        {
            ItemList.Add(child);
        }
    }
}
