using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBuff : Item
{
    protected override void EffectItem()
    {
        GameManager.Instance.JumpBuffTime = 5f;
    }
}
