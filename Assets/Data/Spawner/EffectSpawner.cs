using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : Spawner
{
    private static EffectSpawner instance;
    public static EffectSpawner Instance { get { return instance; } }

    public static string effect_1 = "Effect_1";

    protected override void Awake()
    {
        base.Awake();
        if (EffectSpawner.instance != null) Debug.LogError("There are more than one EffectSpawner in the scene!");
        EffectSpawner.instance = this;
    }

}
