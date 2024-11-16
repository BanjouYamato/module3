using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Rigidbody rb;
    CapsuleCollider CapsuleCollider;
    SphereCollider SphereCollider;
    BoxCollider BoxCollider;
    GameObject attackZone;
    public Color defaultColor;
    public Color invisibleBuffColor;
    private void Awake()
    {
        CapsuleCollider = GetComponent<CapsuleCollider>();
        SphereCollider = GetComponent<SphereCollider>();
        BoxCollider = GetComponent<BoxCollider>();
        attackZone = transform.GetChild(0).gameObject;
    }
    private void Start()
    {
        CapsuleCollider.enabled = true;
        SphereCollider.enabled = false;
    }
    public void PlayerMovement(float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }
    public void PlayerJump(float jumpForce)
    {   
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    public void FallGravity()
    {
        if (rb.velocity.y < 0f)
        {
            rb.AddForce(Vector3.up * (Physics.gravity.y * 1f));
        }
    }
    public void PlayerRoll()
    {   
        if (!GameManager.Instance.FallingToRoll) 
            StartCoroutine(Roll());
    }
    IEnumerator Roll()
    {
        CapsuleCollider.enabled = false;
        SphereCollider.enabled = true;
        GameManager.Instance.FallingToRoll = true;
        yield return new WaitForSeconds(1f);
        CapsuleCollider.enabled = true;
        SphereCollider.enabled = false;
        GameManager.Instance.FallingToRoll = false;
    }
    public void Fall(float fallSpeed)
    {
        rb.velocity = Vector3.down * fallSpeed * Time.fixedDeltaTime;
    }
    public void Attack()
    {   
        if (!GameManager.Instance.Attacking)
            StartCoroutine(Punch());
    }
    IEnumerator Punch()
    {
        GameManager.Instance.Attacking = true;
        yield return new WaitForSeconds(0.5f);
        attackZone.SetActive(GameManager.Instance.Attacking);
        MusicSource.Instance.PlaySound(11, 1f);
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.Attacking = false;
        attackZone.SetActive(GameManager.Instance.Attacking);
        
    }
    public void Death()
    {   
        StartCoroutine(IsDeading());
    }
    IEnumerator IsDeading()
    {
        GameManager.Instance.Death = true;
        GameManager.Instance.speed = 0f;
        yield return new WaitForSeconds(0.3f);
        gameObject.layer = LayerMask.NameToLayer("Invisible");
        yield return new WaitForSeconds(2f);
        CapsuleCollider.enabled = false;
        BoxCollider.enabled = true;
        GameManager.Instance.Defeat();
    }
    void ChangeColor(Color color)
    {
        foreach (Transform body in transform.GetChild(2).gameObject.transform)
        {   
            Renderer colorChange = body.GetComponent<Renderer>();
            if (colorChange != null)
            {
                colorChange.material.color = color;
            }
        }
    }
    public void GetHit()
    {   
        StartCoroutine(hit());
    }
    IEnumerator hit()
    {
        GameManager.Instance.IsHit = true;
        yield return new WaitForSeconds(0.3f);
        GameManager.Instance.InvisibleTime += 0.5f;
        GameManager.Instance.IsHit = false;

    }
    public void ApplyInvisible()
    {   
        if (!GameManager.Instance.Death)
        {
            if (GameManager.Instance.InvisibleTime == 0)
            {
                PlayerMovement(GameManager.Instance.speed);
                gameObject.layer = LayerMask.NameToLayer("Player");
                ChangeColor(defaultColor);
            }
            else if (GameManager.Instance.InvisibleTime > 0 && GameManager.Instance.IsBuffing)
            {
                float tempSpeed = GameManager.Instance.speed * 3f;
                PlayerMovement(tempSpeed);
                gameObject.layer = LayerMask.NameToLayer("Invisible");
                ChangeColor(invisibleBuffColor);
            }
            else if (GameManager.Instance.InvisibleTime > 0)
            {
                PlayerMovement(GameManager.Instance.speed);
                gameObject.layer = LayerMask.NameToLayer("Invisible");
            }
        }
    }
    public void ApplyJumpBuff()
    {
        if (GameManager.Instance.JumpBuffTime != 0)
        {
            float jumpForceTemp = GameManager.Instance.jumpForce + 10f;
            PlayerJump(jumpForceTemp);
        }
        else
        {
            PlayerJump(GameManager.Instance.jumpForce);
        }
    }
}
