using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusBar : DucHienMonoBehaviour
{
    [SerializeField] protected EnemyDamageReceiver damageReceiver;
    [SerializeField] protected Transform hpBar;
    [SerializeField] protected float maxHpBarWidth = 0.1f;


    protected virtual void FixedUpdate()
    {
        //this.UpdateHpBar();
    }
    protected override void LoadComponents()
    {
        this.LoadDamageReceiver();
        this.LoadHpBar();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (damageReceiver != null) return;
        damageReceiver = transform.parent.GetComponentInChildren<EnemyDamageReceiver>();
    }
    protected virtual void LoadHpBar()
    {
        if (hpBar != null) return;
        hpBar = transform.Find("HPBar");
    }

    public virtual void UpdateHpBar()
    {
        if (damageReceiver == null || hpBar == null) return;

        float currentHp = damageReceiver.Hp;
        float maxHp = damageReceiver.MaxHp;

        // Tính toán tỷ lệ giữa HP hiện tại và HP tối đa
        float hpRatio = currentHp / maxHp;

        // Điều chỉnh kích thước của thanh HP Bar dựa trên tỷ lệ HP
        Vector3 scale = hpBar.localScale;
        scale.x = hpRatio * maxHpBarWidth;
        hpBar.localScale = scale;
    }

    public virtual void RebornHpBar()
    {
        if (damageReceiver == null || hpBar == null) return;

        Vector3 scale = hpBar.localScale;
        scale.x = 0;
        hpBar.localScale = scale;
    }





}
