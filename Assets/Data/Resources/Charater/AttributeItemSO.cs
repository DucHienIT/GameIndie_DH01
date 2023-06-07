using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttributeItem", menuName = "ScriptableObject/AttributeItem")]
public class AttributeItemSO : ScriptableObject
{
    public AttributeCode attributeCode;
    public int value;
}
