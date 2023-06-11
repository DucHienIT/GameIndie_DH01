using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : DucHienMonoBehaviour
{
    private static PlayerCtrl instance;
    public static PlayerCtrl Instance => instance;

    [SerializeField] protected CharaterCtrl charater;
    public CharaterCtrl Charater => charater;

    [SerializeField] protected CharaterStatus status;
    public CharaterStatus Status => status;

    [SerializeField] protected Transform characterPositon;
    public Transform CharacterPositon => characterPositon;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerCtrl.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        PlayerCtrl.instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCharater();
        this.LoadStatus();
        this.LoadCharacterPositon();
    }

    protected virtual void LoadCharater()
    {
        if (this.charater != null) return;
        this.charater = GetComponentInChildren<CharaterCtrl>();
        Debug.Log("Load Charater");
    }
    protected virtual void LoadStatus()
    {
        if (this.status != null) return;
        this.status = GetComponentInChildren<CharaterStatus>();
        Debug.Log("Load Status");
    }
    protected virtual void LoadCharacterPositon()
    {
        if (characterPositon != null) return;
        this.characterPositon = this.transform.GetChild(0);
    }

}
