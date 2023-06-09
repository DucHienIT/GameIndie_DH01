using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : BaseButton
{
    protected override void OnClick()
    {
        GameCtrl.Instance.StartGame();
        Debug.Log("Start");
    }
}
