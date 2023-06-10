using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : DucHienMonoBehaviour
{
    private static SceneLoadManager _instance;
    public static SceneLoadManager Instance => _instance;

    protected override void Awake()
    {
        base.Awake();
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        SceneLoadManager._instance = this;

        DontDestroyOnLoad(this.transform.parent.gameObject);
    }

    public void ExitCurrentScene()
    {
        // Lấy index của scene hiện tại
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Kiểm tra nếu scene trước đó tồn tại
        if (currentSceneIndex > 0)
        {
            // Tải lại scene trước đó
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
        else
        {
            // Nếu không có scene trước đó, thoát game
            Application.Quit();
        }
    }

    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
