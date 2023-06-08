using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Charater", menuName = "ScriptableObject/CharaterSO")]
public class CharaterSO : ScriptableObject
{
    public string charaterName = "Cyrbon";
    public int hpMax = 100;
    public int atk = 4;
    public int def = 2;
    public int spd = 2;
    public int atkSpd = 5;
}
