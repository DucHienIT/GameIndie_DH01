using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCoin : DucHienMonoBehaviour
{
    private static DisplayCoin _instance;
    public static DisplayCoin Instance => _instance;

    [SerializeField] protected Text levelText;

    protected override void Start()
    {
        base.Start();
        this.UpdateLevelText();
    }
    protected override void Awake()
    {
        base.Awake();
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevelText();

    }
    protected virtual void LoadLevelText()
    {
        if (this.levelText != null) return;
        this.levelText = GetComponentInChildren<Text>();
    }
    public virtual void UpdateLevelText()
    {
        if (PlayerCtrl.Instance == null) return;
        this.levelText.text = PlayerCtrl.Instance.Charater.Inventory.TotelCoin.ToString(); 
    }
}
