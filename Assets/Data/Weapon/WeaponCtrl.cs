using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCtrl : DucHienMonoBehaviour
{
    
    [SerializeField] protected WeaponSO weaponSO;
    public WeaponSO WeaponSO { get { return weaponSO; } }

    [SerializeField] protected WeaponDespawn weaponDespawn;
    public WeaponDespawn WeaponDespawn { get => weaponDespawn; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySO();
        this.LoadWeaponDespawn();


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
}