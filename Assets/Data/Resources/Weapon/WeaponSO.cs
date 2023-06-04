using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "Weapon", menuName = "ScriptableObject/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public string name = "Weapon_1";
    public int atk = 2;
    public int def = 2;
    public int hp = 5;
}
