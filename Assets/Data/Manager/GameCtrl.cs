using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrl : DucHienMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if(GameCtrl.instance != null)
            Debug.LogError("GameCtrl is already exist");
        GameCtrl.instance = this;
    }

    public virtual void StartGame()
    {
        SceneManager.LoadScene("MainGame");
        
    }

    public virtual void PauseGame()
    {
        Time.timeScale = 0;
    }
    public virtual void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public virtual void QuitGame()
    {
        Application.Quit();
    }
    public virtual void Test()
    {
        Debug.Log("Test");
    }
}
