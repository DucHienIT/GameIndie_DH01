using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSpawner : Spawner
{
    private static EquipSpawner instance;
    public static EquipSpawner Instance { get { return instance; } }

    [Header("List")]
    [SerializeField] public List<string> EquipList;

    protected override void Awake()
    {
        base.Awake();
        if (EquipSpawner.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        EquipSpawner.instance = this;

        DontDestroyOnLoad(this.gameObject);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListItem();
    }
    protected virtual void LoadListItem()
    {
        if (this.EquipList.Count > 0) return;
        Transform prefabObj = this.transform.Find("Prefabs");
        foreach (Transform child in prefabObj)
        {
            EquipList.Add(child.name);
        }
    }


}
