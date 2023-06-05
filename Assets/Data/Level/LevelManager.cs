using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : DucHienMonoBehaviour
{
    [SerializeField] protected List<LevelData> levelData = new List<LevelData>();

    [SerializeField] protected int currentLevelIndex = 1;
    public int CurrentLevelIndex => currentLevelIndex;
    [SerializeField] protected int currentExp = 0;
    public int CurrentExp => currentExp;

    [SerializeField] protected int currentExpToNextLevel = 0;
    public int CurrentExpToNextLevel => currentExpToNextLevel;


    public virtual void AddExp(int exp) 
    {
        currentExp += exp;
        if (currentExp >= currentExpToNextLevel) //Check if level up
        {
            UpLevel();
        }
    }

    protected virtual void UpLevel()
    {
        currentLevelIndex++;
        currentExp = 0;
        currentExpToNextLevel = levelData[currentLevelIndex - 1].requiredExp;
    }
 
    protected override void Awake()
    {
        base.Awake();
        this.LoadLevelData();
        currentExpToNextLevel = levelData[currentLevelIndex-1].requiredExp;
    }
    protected virtual void LoadLevelData()
    {
        for(int i = 1; i <= 30; i++)
        {
            LevelData level = new LevelData();
            level.levelIndex = i;
            level.requiredExp = i * 100;
            levelData.Add(level);
        }
    }    
}
