using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : DucHienMonoBehaviour
{
    private static RoundManager instance;
    public static RoundManager Instance => instance;

    [SerializeField] protected int Round;
    public int RoundText => Round;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        RoundManager.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRoud();
    }
    protected virtual void LoadRoud()
    {
        this.Round = PlayerPrefs.GetInt("Round", 1);
        Debug.Log("Load Round: " + this.Round);
    }
    public virtual void NextRound()
    {
        this.Round++;
        PlayerPrefs.SetInt("Round", this.Round);
        PlayerPrefs.Save();

        InventoryManager.Instance.Toggle();
    }
}
