using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : BaseButton
{
    protected override void OnClick()
    {
        if (InventoryManager.Instance.IsOpen)
            InventoryManager.Instance.Toggle();
    }
}
