using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBuff : Item
{
    protected override void EffectItem()
    {
        GameManager.Instance.InvisibleTime = 5f;
        GameManager.Instance.IsBuffing = true;
    }
}
