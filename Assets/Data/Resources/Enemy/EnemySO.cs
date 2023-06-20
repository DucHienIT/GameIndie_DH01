using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName= "Enemy", menuName = "ScriptableObject/Enemy")]
public class EnemySO : ScriptableObject
{
    public string enemyName = "Enemy_1";
    public int hpMax = 10;
    public int exp = 10;
    public int damage = 1;
    public int coin = 1;
    public List<float> rateEachRound = new List<float>();
}
