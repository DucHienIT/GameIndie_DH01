using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : DucHienMonoBehaviour
{
    private static RoundManager instance;
    public static RoundManager Instance => instance;

    [SerializeField] protected int Round;
    [SerializeField] protected List<int> timeRound;
    public List<int> TimeRound => timeRound;
    public int RoundText => Round;
    public int RoundCount => Round;


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
        //this.Round = PlayerPrefs.GetInt("Round", 1);
        //Debug.Log("Load Round: " + this.Round);
        this.Round = 1;
    }
    public virtual void NextRound()
    {
        this.Round++;
       // PlayerPrefs.SetInt("Round", this.Round);
       // PlayerPrefs.Save();
        InventoryManager.Instance.Toggle();
    }
}
