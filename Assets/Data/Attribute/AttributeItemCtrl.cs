using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeItemCtrl : DucHienMonoBehaviour
{
    [SerializeField] protected AttributeItemSO attributeItemSO;
    public AttributeItemSO AttributeItemSO => attributeItemSO;

    [SerializeField] protected Text text;
    public Text Text { get { return text; } }

    [SerializeField] protected AttributeItemValue attributeItemValue;
    public AttributeItemValue AttributeItemValue { get { return attributeItemValue; } }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttributeItemSO();
        this.LoadText();
        this.LoadAttributeItemValue();
        this.UpdateText();
    }
    protected virtual void LoadAttributeItemSO()
    {
        if (this.attributeItemSO != null) return;
        string path = "Charater/" + transform.name;
        this.attributeItemSO = Resources.Load<AttributeItemSO>(path);
    }
    protected virtual void LoadText()
    {
        if (this.text != null) return;
        this.text = GetComponentInChildren<Text>();
    }
    protected virtual void LoadAttributeItemValue()
    {
        if (this.attributeItemValue != null) return;
        this.attributeItemValue = GetComponentInChildren<AttributeItemValue>();
    }

    protected virtual void UpdateText()
    {
        if (this.text == null) return;
        this.text.text = this.transform.name + ": " + this.attributeItemValue.Value;
    }

}
