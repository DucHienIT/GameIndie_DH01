﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPosition : MonoBehaviour
{
    private static CharacterPosition instance;
    public static CharacterPosition Instance { get { return instance; } }

    [SerializeField] protected Transform characterTransform;
    public Transform CharacterTransform => characterTransform;
         
    protected virtual void Awake()
    {
        if (CharacterPosition.instance != null)
        {
            Debug.LogError("There is more than one CharacterPosition in the scene!");
        }
        CharacterPosition.instance = this;
    }

    protected virtual void FixedUpdate()
    {
        this.characterTransform = transform;
    }
}
