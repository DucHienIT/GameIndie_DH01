using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageReceiver : DamageReceiver
{
    [Header("Character")]
    [SerializeField] protected CharaterCtrl characterCtrl;

    protected override void Start()
    {
        base.Start();
        this.maxHp = PlayerCtrl.Instance.Status.Health;
        this.hp = this.maxHp;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharaterCtrl();
    }

    protected virtual void LoadCharaterCtrl()
    {
        if (this.characterCtrl != null) return;
        this.characterCtrl = transform.parent.GetComponent<CharaterCtrl>();

        Debug.Log(transform.name + ": LoadCharaterCtrl", gameObject);
    }

    public override void Sub(int value)
    {
        base.Sub(value);
        PlayerCtrl.Instance.Status.UpdateHeth(-value);
    }

    protected override void OnDead()
    {
        Destroy(PlayerCtrl.Instance.gameObject);
        SceneLoadManager.Instance.LoadNewScene("GameOver");
    }
}
