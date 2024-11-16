using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableTrap : Trap
{
    private float speed = 10f;
    BoxCollider BoxCollider;
    protected override void OnEnable()
    {
        base.OnEnable();
        AudioSource = transform.GetChild(1).GetComponent<AudioSource>();
        BoxCollider = GetComponent<BoxCollider>();
        GetSounds();
    }
    private void OnDisable()
    {
        BoxCollider.enabled = true;
    }
    protected override void Movement()
    {   
        if (rb != null)
        {
            rb.MovePosition(rb.position + transform.forward * speed * Time.fixedDeltaTime);
        }
        else
        {
            Debug.Log("rb movable loi");
        }
    }
    protected override void Flip()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    protected override void GetSounds()
    {
        AudioSource.clip = MusicSource.Instance.GetSound(0);
        AudioSource.loop = true;
        AudioSource.Play();
        AudioSource.volume = VolumeValueControl.Instance.soundVolume;
    }
    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player"))
            {
                AudioSource.PlayOneShot(MusicSource.Instance.GetSound(1), VolumeValueControl.Instance.soundVolume);
                BoxCollider.enabled = false;
            }

    }
}
