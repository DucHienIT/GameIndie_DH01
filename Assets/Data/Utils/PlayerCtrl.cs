using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : DucHienMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [SerializeField] protected CharaterCtrl charater;
    public CharaterCtrl Charater => charater;

    protected override void Awake()
    {
        base.Awake();
        PlayerCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharater();
    }

    protected virtual void LoadCharater()
    {
        if (this.charater != null) return;
        this.charater = GetComponentInChildren<CharaterCtrl>();
        Debug.Log("Load Charater");
    }
}
