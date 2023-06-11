using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCtrl : DucHienMonoBehaviour
{
    
    [SerializeField] protected WeaponSO weaponSO;
    public WeaponSO WeaponSO { get { return weaponSO; } }

    [SerializeField] protected WeaponDespawn weaponDespawn;
    public WeaponDespawn WeaponDespawn { get => weaponDespawn; }

    [SerializeField] protected Transform priceText;
    public Transform PriceText => priceText;

    protected override void Start()
    {
        base.Start();
        this.UpdatePriceText();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySO();
        this.LoadWeaponDespawn();
        this.LoadPriceText();


    }
    protected virtual void LoadEnemySO()
    {
        if (this.weaponSO != null) return;
        string path = "Weapon/" + transform.name;
        this.weaponSO = Resources.Load<WeaponSO>(path);
    }

    protected virtual void LoadWeaponDespawn()
    {
        if (this.weaponDespawn != null) return;
        this.weaponDespawn = GetComponentInChildren<WeaponDespawn>();
    }
    protected virtual void LoadPriceText()
    {
        if (this.priceText != null) return;
        this.priceText = transform.Find("Price");
    }

    protected virtual void UpdatePriceText()
    {
        if (this.priceText == null) return;
        this.priceText.GetComponent<Text>().text = this.weaponSO.price.ToString() + "$";
    }

}