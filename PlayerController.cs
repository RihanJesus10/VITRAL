using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jump;
    public float move;
    public float speed;
    bool grounded;
    public Vector2 boxSize;
    public float castDistance;
    public LayerMask groundLayer;
    private Animator anim;
    private bool isFacingRight;
    public bool invencivel = false;
    private SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jump * 10));
        }

        if(move != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        anim.SetBool("isJumping", !isGrounded());

        if (!isFacingRight && move > 0)
        {
            Flip();
        }
        else if (isFacingRight && move < 0) {
            Flip();
        }

    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }


    public bool isGrounded()
    {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer ))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vidro"))
        {
    
            if(!invencivel)
            {
                invencivel = true;
                FindAnyObjectByType<Vidro>().PerderVida(1);
                rb.AddForce(new Vector2(rb.linearVelocity.x, jump * 20));
                StartCoroutine("invulneravel");
                
            }
        }
    }

    IEnumerator invulneravel()
    {
        for (float I = 0; I < 1; I += 0.1f)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = enabled;
            yield return new WaitForSeconds(0.1f);
        }

        invencivel = false;
    }


    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        grounded = true;
    //    }
    //}
    //private void OnCollisionExit2D(Collision2D other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //    {
    //        grounded = false;
    //    }
    //}
}
