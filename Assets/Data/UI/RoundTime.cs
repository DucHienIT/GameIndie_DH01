using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTime : DucHienMonoBehaviour
{
    [SerializeField] protected Transform Round;
    [SerializeField] protected Transform TimeText;
    [SerializeField] private float roundTime = 30f;

    private float timer = 0;
    private float time = 30f;
    private float timeDelay = 1f;


    protected override void Start()
    {
        base.Start();
        this.time = RoundManager.Instance.TimeRound[RoundManager.Instance.RoundCount-1];
    }
    protected virtual void FixedUpdate()
    {
        this.RunTimer();
        this.UpdateRound();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRoud();
        this.LoadTime();
    }

    protected virtual void LoadRoud()
    {
        if (this.Round != null) return;
        this.Round = transform.Find("Round");
    }
    protected virtual void LoadTime()
    {
        if (this.TimeText != null) return;
        this.TimeText = transform.Find("Time");
        this.TimeText.GetComponent<Text>().text = "Time: " + this.time;

    }
    protected virtual void UpdateRound()
    {
        this.Round.GetComponent<Text>().text = "Round " + RoundManager.Instance.RoundText;
    }
    protected virtual void UpdateTime()
    {
        if (this.TimeText == null) return;
        this.TimeText.GetComponent<Text>().text = "Time: " + this.time;
    }

    public virtual void RunTimer()
    {
        if(this.time <= 0)
        {
            RoundManager.Instance.NextRound();
            this.time = roundTime;
            return;
        }
        if (this.timer < this.timeDelay)
        {
            this.timer += Time.fixedDeltaTime;
            return;
        }
        this.timer = 0;
        this.time -= 1;
        this.UpdateTime();
    }
}
