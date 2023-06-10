using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomButton : BaseButton
{
    protected override void OnClick()
    {
        StoreTableRandom.Instance.LoadRandomItem();
        Debug.Log("Random Item List");
    }
}
