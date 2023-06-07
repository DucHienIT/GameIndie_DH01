using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : DucHienMonoBehaviour
{
    
    [SerializeField] protected CoinDespawn coinDespawn;
    public CoinDespawn CoinDespawn { get => coinDespawn; }

    [SerializeField] protected int coinValue = 1;
    public int CoinValue { get => coinValue; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeaponDespawn();
    }


    protected virtual void LoadWeaponDespawn()
    {
        if (this.coinDespawn != null) return;
        this.coinDespawn = GetComponentInChildren<CoinDespawn>();
    }

    public virtual void SetCoinValue(int value)
    {
        this.coinValue = value;
    }
}