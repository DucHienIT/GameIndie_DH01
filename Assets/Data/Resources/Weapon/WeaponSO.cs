using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "Weapon", menuName = "ScriptableObject/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public string name = "Weapon_1";
    public List<Attribute> Attribute;
    public int price = 1;
    public bool equipment = true;
}
