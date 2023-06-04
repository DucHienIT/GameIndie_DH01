using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "Weapon", menuName = "ScriptableObject/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    public string enemyName = "Weapon";
    public int atk = 2;
    public int def = 2;
}
