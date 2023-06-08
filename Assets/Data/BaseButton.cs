using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : DucHienMonoBehaviour
{
    [Header("Base Button")]
    [SerializeField] protected Button Button;

    protected override void Start()
    {
        base.Start();
        this.AddOnClickEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }
    protected virtual void LoadButton()
    {
        if (this.Button != null) return;
        this.Button = GetComponent<Button>();
        Debug.Log("Load Button: " + transform.name, gameObject);
    }
    protected virtual void AddOnClickEvent()
    {
        this.Button.onClick.AddListener(this.OnClick);
        Debug.Log("Add On Click Event: " + transform.name, gameObject);
    }
    protected abstract void OnClick();

}
