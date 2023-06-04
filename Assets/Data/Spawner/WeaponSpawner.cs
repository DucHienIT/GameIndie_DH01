using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : Spawner
{
    private static WeaponSpawner instance;
    public static WeaponSpawner Instance { get { return instance; } }

    public static string Weapon_1 = "Weapon_1";
   

    protected override void Awake()
    {
        base.Awake();
        if (WeaponSpawner.instance != null) Debug.LogError("There are more than one WeaponSpawner in the scene!");
        WeaponSpawner.instance = this;
    }

}
