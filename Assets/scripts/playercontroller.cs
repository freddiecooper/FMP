using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    public float speed;
    public float upForce;
    public int health = 100;
    public static int coins = 0;
    public Transform buyPoint;
    public GameObject coinPrefab;

    private bool FacingRight = true;
    private BoxCollider2D boxCollider2d;
    private Rigidbody2D rb;

    private void Awake()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        //anim = GetComponent<Animator>();
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
            float extraHeightText = .1f;
            RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, groundLayerMask);
            Color rayColor;
            if(raycastHit.collider != null)
            {
                rayColor = Color.green;
            }
            else
            {
                rayColor = Color.red;
            }
            Debug.DrawRay(boxCollider2d.bounds.center + new Vector3(boxCollider2d.bounds.extents.x, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText), rayColor);
            Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, 0), Vector2.down * (boxCollider2d.bounds.extents.y + extraHeightText), rayColor);
            Debug.DrawRay(boxCollider2d.bounds.center - new Vector3(boxCollider2d.bounds.extents.x, boxCollider2d.bounds.extents.y + extraHeightText), Vector2.right * (boxCollider2d.bounds.extents.x * 2), rayColor);
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
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("coin"))
        {
            Debug.Log("hi");
            coins++;
            //keyAmount.text = "coins: " + coins;
            Destroy(other.gameObject);
        }

        /*if(other.gameObject.CompareTag("shop") && coins >=4)
        {
            if(Input.GetKey ("b"))
            {
                weaponDrop();
                coins -= 4;
            }
            
        }*/
    }

    /*void weaponDrop()
    {
        Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
        Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
        Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
        Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
        Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
    }*/
}
