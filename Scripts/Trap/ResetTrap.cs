using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trap") || other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
