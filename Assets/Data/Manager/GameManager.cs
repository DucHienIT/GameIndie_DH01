using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : DucHienMonoBehaviour
{
    private void OnApplicationQuit()
    {
        Debug.Log("Game is quitting...");
        PlayerPrefs.DeleteAll();
    }
}
