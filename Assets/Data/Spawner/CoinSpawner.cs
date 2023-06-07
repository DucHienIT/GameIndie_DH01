using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    private static CoinSpawner instance;
    public static CoinSpawner Instance { get { return instance; } }

    public static string Coin = "Coin";

    protected override void Awake()
    {
        base.Awake();
        if (CoinSpawner.instance != null) Debug.LogError("There are more than one CoinSpawner in the scene!");
        CoinSpawner.instance = this;
    }

}
