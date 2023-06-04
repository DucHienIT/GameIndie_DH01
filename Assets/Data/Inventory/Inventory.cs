using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : DucHienMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> itemInventories;

    protected override void Start()
    {
        base.Start();
       
    }

}
