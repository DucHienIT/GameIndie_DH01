using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharater : FollowTarget
{
    [SerializeField] protected float limitX = 4f;

    [SerializeField] protected float cameraSize = 2.198711f;
    protected override void Following()
    {
        if (PlayerCtrl.Instance == null) return;
        Transform charater = PlayerCtrl.Instance.CharacterPositon;
        if (charater.position.x + cameraSize > limitX || charater.position.x - cameraSize < -limitX) return;
        transform.position = new Vector3(charater.position.x, this.transform.position.y, -10f);
    }
}
