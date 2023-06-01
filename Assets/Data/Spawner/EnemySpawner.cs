using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get { return instance; } }

    public static string Enemy_1 = "Enemy_1";
    public static string Enemy_2 = "Enemy_2";

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null) Debug.LogError("There are more than one EnemySpawner in the scene!");
        EnemySpawner.instance = this;
    }

}
