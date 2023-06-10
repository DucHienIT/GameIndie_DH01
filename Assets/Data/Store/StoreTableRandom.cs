using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreTableRandom : DucHienMonoBehaviour
{
    private static StoreTableRandom instance;
    public static StoreTableRandom Instance { get { return instance; } }

    [Header("StoreTableRandom")]
    [SerializeField] protected int itemSpawnLimit = 6;

    protected override void Awake()
    {
        base.Awake();
        if (StoreTableRandom.instance != null) Debug.LogError("There are more than one StoreTableRandom in the scene!");
        StoreTableRandom.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        this.LoadRandomItem();
    }


    public virtual void LoadRandomItem()
    {
        if (WeaponSpawner.Instance == null) return;
        if(WeaponSpawner.Instance.Holder.childCount > 0) this.DespawnActiveItem();
        int itemSpawnCount = 0;
        while (itemSpawnCount < this.itemSpawnLimit)
        {
            if (this.RandomItem()) itemSpawnCount++;
        }
    }
    protected virtual bool RandomItem()
    {
        int randomIndex = Random.Range(0, WeaponSpawner.Instance.ItemList.Count);
        string itemName = WeaponSpawner.Instance.ItemList[randomIndex].name;
        Transform obj = WeaponSpawner.Instance.Spawn(itemName, transform.position, transform.rotation);
        obj.gameObject.SetActive(true);
        if (obj == null) return false;
        return true;

    }

    protected virtual void DespawnActiveItem()
    {
        foreach (Transform child in WeaponSpawner.Instance.Holder)
        {
            if (!child.gameObject.activeSelf) continue;
            child.GetComponentInChildren<Despawn>().DespawnObject();
        }
    }   
}
