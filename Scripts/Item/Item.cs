using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected virtual void EffectItem() { }
    protected virtual void GetSound()
    {
        MusicSource.Instance.PlaySound(4, 1);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("ResetObstacle") || other.gameObject.name == "Cone(Clone)" || other.gameObject.name == "TrafficLight(Clone)")
        {
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Player"))
        {   
            EffectItem();
            GetSound();
            gameObject.SetActive(false);
        }
    }
}
