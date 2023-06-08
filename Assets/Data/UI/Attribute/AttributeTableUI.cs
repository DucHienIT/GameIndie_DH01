using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeTableUI : DucHienMonoBehaviour
{
    private static AttributeTableUI instance;
    public static AttributeTableUI Instance => instance;

    [SerializeField] protected bool isOpen = true;

    private int currentItemCount = 0;
    private int limitCount = 4;

    protected override void Start()
    {
        this.Close();
    }
    protected override void Awake()
    {
        base.Awake();
        AttributeTableUI.instance = this;
    }

    protected virtual void FixedUpdate()
    {
        if (!this.isOpen) return;
        this.UpdateAttributeTable();
        GameCtrl.Instance.PauseGame();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen)
        {
            this.Open();
        }
        else
        {
            this.Close();
        }
    }    
    public virtual void Open()
    {  
        gameObject.SetActive(true);
    }
    public virtual void Close()
    {
        gameObject.SetActive(false);

    }

    public virtual void UpdateAttributeTable()
    {
        if (this.currentItemCount >= this.limitCount) return;
        foreach (Transform child in AttributeItemSpawner.Instance.ItemList)
        {
            Transform obj = AttributeItemSpawner.Instance.Spawn(child.name, transform.position, transform.rotation);
            obj.gameObject.SetActive(true);
        }
        this.currentItemCount += AttributeItemSpawner.Instance.ItemList.Count;
    }
}
