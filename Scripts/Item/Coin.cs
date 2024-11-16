using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    protected override void EffectItem()
    {
        base.EffectItem();
    }
    protected override void GetSound()
    {
        MusicSource.Instance.PlaySound(5, 0.3f);
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.UpdateCoin();
        }
    }
}
