using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trap : MonoBehaviour 
{   
    protected Rigidbody rb;
    protected AudioSource AudioSource;
    protected virtual void OnEnable()
    {   
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.Log("rb Loi");
        }
        Flip();
    }
    protected void FixedUpdate()
    {
        Movement();
    }
    protected virtual void Movement() { }
    protected virtual void GetSounds() { }
    protected virtual void Flip()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
