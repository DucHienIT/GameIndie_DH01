using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : BaseButton
{
    protected override void OnClick()
    {
        if (!CharaterImpact.Instance.OnGround) return;
        InputManager.Instance.SetOnJump(true);
    }


}
