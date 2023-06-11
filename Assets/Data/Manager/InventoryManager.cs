using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryManager : DucHienMonoBehaviour
{
    private static InventoryManager instance;
    public static InventoryManager Instance { get { return instance; } }

    [SerializeField] protected bool isOpen = false;
    public bool IsOpen => isOpen;

    protected override void Awake()
    {
        base.Awake();
        if (InventoryManager.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        InventoryManager.instance = this;

    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen)
        {
            this.Open();
        }
        else
        {
            this.Close();
        }
    }

    public virtual void Open()
    {
        SceneLoadManager.Instance.LoadNewScene("Store");
        GameCtrl.Instance.PauseGame();
    }

    public virtual void Close()
    {
        SceneLoadManager.Instance.ExitCurrentScene();
        GameCtrl.Instance.ResumeGame();
    }
}
