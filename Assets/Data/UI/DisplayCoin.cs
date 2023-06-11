using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCoin : DucHienMonoBehaviour
{
    [SerializeField] protected Text levelText;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevelText();

    }
    protected virtual void Update()
    {
        this.UpdateLevelText();
    }
    protected virtual void LoadLevelText()
    {
        if (this.levelText != null) return;
        this.levelText = GetComponentInChildren<Text>();
    }
    protected virtual void UpdateLevelText()
    {
        this.levelText.text = PlayerCtrl.Instance.Charater.Inventory.TotelCoin.ToString(); 
    }

}
