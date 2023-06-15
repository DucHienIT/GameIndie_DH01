using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseButton : DucHienMonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Base Button")]
    [SerializeField] protected Button button;

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
        if (this.button != null) return;
        this.button = GetComponent<Button>();
        Debug.Log("Load Button: " + transform.name, gameObject);
    }
    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
        Debug.Log("Add On Click Event: " + transform.name, gameObject);
    }
    protected abstract void OnClick();

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
       
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
