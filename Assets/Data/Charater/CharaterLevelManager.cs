using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterLevelManager : LevelManager
{
    private static CharaterLevelManager instance;
    public static CharaterLevelManager Instance { get { return instance; } }

    protected override void Awake()
    {
        base.Awake();
        if (CharaterLevelManager.instance != null) 
            Debug.LogError("There are more than one CharaterLevelManager in the scene!");
        CharaterLevelManager.instance = this;
    }
    protected override void UpLevel()
    {
        base.UpLevel();
        AttributeTableUI.Instance.Toggle();
    }
}
