using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;

    public string itemName = "no-name";
    public int defaultMaxStack = 7;
}
