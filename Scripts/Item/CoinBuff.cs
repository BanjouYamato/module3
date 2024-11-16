using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBuff : Item
{
    protected override void EffectItem()
    {
        GameManager.Instance.CoinBuffTime = 5f;
    }
}
