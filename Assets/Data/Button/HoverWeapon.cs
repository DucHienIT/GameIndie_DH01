using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverWeapon : DucHienMonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        this.TurnOnRecycleButton();
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        this.TurnOffRecycleButton();
    }

    protected virtual void TurnOnRecycleButton()
    {
        this.transform.Find("Recycle").gameObject.SetActive(true);
    }
    protected virtual void TurnOffRecycleButton()
    {
        this.transform.Find("Recycle").gameObject.SetActive(false);
    }



}
