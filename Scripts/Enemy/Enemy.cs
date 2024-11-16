using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Animator anim;
    [SerializeField] bool isPunched;
    [SerializeField] float speed;
    [SerializeField] bool isChashing;
    [SerializeField] PlayerControler pControler;
    [SerializeField] Transform player;
    private void OnEnable()
    {   
        rb = GetComponent<Rigidbody>();
        anim = transform.GetChild(0).GetComponent<Animator>();
        pControler = FindObjectOfType<PlayerControler>();
        player = FindObjectOfType<Transform>();
        gameObject.layer = LayerMask.NameToLayer("Enemy");
    }
    private void OnDisable()
    {
        isPunched = false;
        isChashing = false;
    }
    private void Update()
    {   
        float playerDis = Vector3.Distance(transform.position, player.position);
        if (playerDis <= 20f && !GameManager.Instance.IsBuffing)
        {
            StartCoroutine(Surprise());
        }
        if (isChashing)
            speed = 10;
        else
            speed = 0;
        if (isChashing)
        {
            anim.SetBool("isChasing", isChashing);
            rb.MovePosition(rb.position - transform.forward * speed * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        SwitchLane();
        
    }
    IEnumerator Surprise()
    {
        anim.SetTrigger("Allert");
        yield return new WaitForSeconds(1f);
        isChashing = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AttackZone"))
        {
            isPunched = true;
            MusicSource.Instance.PlaySound(13, 1f);
            MusicSource.Instance.PlaySound(16, 1f);
            speed = 0f;
            anim.SetBool("IsPunched", isPunched);
            gameObject.layer = LayerMask.NameToLayer("Invisible");
            GameManager.Instance.KillEnemy(100, 20);
        }
    }
    void SwitchLane()
    {
        Vector3 pPos = new(pControler.GetLaneX(), transform.position.y, transform.position.z);
        transform.position= Vector3.Lerp(transform.position, pPos, speed * Time.fixedDeltaTime);
    }
}
