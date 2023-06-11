using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharater : FollowTarget
{
    protected override void Following()
    {
        Transform charater = PlayerCtrl.Instance.CharacterPositon;
        transform.position = new Vector3(charater.position.x, charater.position.y, -10f);
    }
}
