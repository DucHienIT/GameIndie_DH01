using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance { get { return instance; } }

    public static string bulletOne = "Bullet_1";
    public static string bullet_2 = "Bullet_2";

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null) Debug.LogError("There are more than one BulletSpawner in the scene!");
        BulletSpawner.instance = this;
    }

}
