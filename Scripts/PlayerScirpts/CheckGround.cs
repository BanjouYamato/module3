using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            GameManager.Instance.GroundCheck = true;
            GameManager.Instance.TrapCheck = false;
            MusicSource.Instance.PlaySound(10, 1f);
        }
        if (other.gameObject.CompareTag("Trap"))
        {
            GameManager.Instance.GroundCheck = true;
            GameManager.Instance.TrapCheck = true;
            MusicSource.Instance.PlaySound(10, 1f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
            GameManager.Instance.GroundCheck = true;
            GameManager.Instance.TrapCheck = false;
        if (other.gameObject.CompareTag("Trap"))
        {
            GameManager.Instance.GroundCheck = true;
            GameManager.Instance.TrapCheck = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        { 
            GameManager.Instance.GroundCheck = false;
        }
    }
}
