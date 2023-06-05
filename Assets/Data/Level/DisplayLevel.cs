using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLevel : DucHienMonoBehaviour
{
    [SerializeField] protected Text levelText;
    [SerializeField] protected Transform expBar;
    protected float minExpBarScaleX = 0f;
    protected float maxExpBarScaleX = 0.3248363f;
    protected float minExpBarPosX = -1.442f;
    protected float maxExpBarPosX = 0f;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevelText();
        this.LoadExpBar();

    }
    protected virtual void FixedUpdate()
    {
        this.UpdateLevelText();
        this.UpdateExpBar();
    }
    protected virtual void LoadLevelText()
    {
        if (this.levelText != null) return;
        this.levelText = GetComponentInChildren<Text>();
    }
    protected virtual void LoadExpBar()
    {
        if (this.expBar != null) return;
        this.expBar = GetComponentInChildren<Transform>();
    }
    protected virtual void UpdateLevelText()
    {
        this.levelText.text = "Lv " + CharaterLevelManager.Instance.CurrentLevelIndex;
    }
    protected virtual void UpdateExpBar()
    {
        float currentExp = CharaterLevelManager.Instance.CurrentExp;
        float maxExp = CharaterLevelManager.Instance.CurrentExpToNextLevel;

        float normalizedExp = Mathf.Clamp01(currentExp / maxExp);

        float scaleX = Mathf.Lerp(minExpBarScaleX, maxExpBarScaleX, normalizedExp);
        float posX = Mathf.Lerp(minExpBarPosX, maxExpBarPosX, normalizedExp);

        expBar.localScale = new Vector3(scaleX, expBar.localScale.y, expBar.localScale.z);
        expBar.localPosition = new Vector3(posX, expBar.localPosition.y, expBar.localPosition.z);
    }

}
