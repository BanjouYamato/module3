using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBuff : Item
{
    protected override void EffectItem()
    {
        GameManager.Instance.ScoreBuffTime = 5f;
    }
}
