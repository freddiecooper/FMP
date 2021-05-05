using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    public float speed;
    public float upForce;
    public int health = 100;

    private bool FacingRight = true;
    private BoxCollider2D boxCollider2d;
    private Rigidbody2D rb;

    private void Awake()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2( move * speed, rb.velocity.y);

        if(IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, upForce);
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * .5f);
        }

        if (move > 0 && !FacingRight)
			{
				Flip();
			}
			else if (move < 0 && FacingRight)
			{
				Flip();
			}
    }
    
    private bool IsGrounded()
        {
            float extraHeightText = .05f;
            RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeightText, groundLayerMask);
            Color rayColor;
            if(raycastHit.collider != null)
            {
                rayColor = Color.green;
            }
            else
            {
                rayColor = Color.red;
            }
            Debug.DrawRay(boxCollider2d.bounds.center, Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText),rayColor);
            return raycastHit.collider != null;
        }
        
    private void Flip()
    {
        FacingRight = !FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void TakeDamage (int playerDamage)
    {
        health -= playerDamage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
