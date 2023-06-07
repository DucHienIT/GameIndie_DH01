using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy")]
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected virtual void FixedUpdate()
    {
        enemyCtrl.Animator.SetBool("isHurt", false);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();

        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }


    protected override void OnDead()
    {
        this.enemyCtrl.EnemyDespawn.DespawnObject();
        this.OnDeadEffect(); //hiệu ứng 
        this.DropCoin(); //rớt tiền
        CharaterLevelManager.Instance.AddExp(this.enemyCtrl.EnemySO.exp);
    }
    protected virtual void OnDeadEffect()
    {
        string fxName = EffectSpawner.effect_1;
        Transform fxOnDead = EffectSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual void DropCoin()
    {
        string coin = CoinSpawner.Coin;
        Transform coinTransform = CoinSpawner.Instance.Spawn(coin, transform.position, transform.rotation);
        coinTransform.gameObject.SetActive(true);
        coinTransform.GetComponent<CoinCtrl>().SetCoinValue(this.enemyCtrl.EnemySO.coin);
    }
    public override void Reborn()
    {
        this.maxHp = this.enemyCtrl.EnemySO.hpMax;
        base.Reborn();
        this.enemyCtrl.EnemyStatusBar.RebornHpBar();
        
    }
    public override void Sub(int value)
    {
        base.Sub(value);
        enemyCtrl.Animator.SetBool("isHurt", true);
        this.enemyCtrl.EnemyStatusBar.UpdateHpBar();

    }
}
