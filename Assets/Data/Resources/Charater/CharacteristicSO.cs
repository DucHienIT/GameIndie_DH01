using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characteristic", menuName = "ScriptableObject/CharacteristicSO")]
public class CharacteristicSO : ScriptableObject
{
    public int RankCharacteristic = 1;
    public int hpMax = 2;
    public int atk = 1;
    public int def = 1;
    public int spd = 1;
    public int atkPpd = 5;
}