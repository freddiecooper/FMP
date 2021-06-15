using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayerMask;
    public float speed;
    public float upForce;
    public float keep;
    public int health = 100;
    public int game;
    public static int coins = 0;
    public Transform buyPoint;
    public GameObject coinPrefab;
    public Chain pull;
    public Text coinsText1;
    public static Text coinsText;
    

    private bool FacingRight = true;
    private CapsuleCollider2D capsuleCollider2d;
    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        capsuleCollider2d = transform.GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        coinsText = coinsText1;
        
        if(pull.pull == false)
        {
            float move = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2( move * speed, rb.velocity.y);
            if (move > 0 && !FacingRight)
		    {
		    	Flip();
		    }
		    else if (move < 0 && FacingRight)
		    {
		    	Flip();
		    }
            else
            {
                anim.SetBool("Idle",true);
            }

            if (move > 0 && IsGrounded())
		    {
                anim.SetBool("Run",true);
		    }
		    else if (move < 0 && IsGrounded())
		    {
                anim.SetBool("Run",true);
		    }
            else
            {
                anim.SetBool("Run",false);
            }

            if(move == 0)
            {
                anim.SetBool("Idle",true);
            }
            else
            {
                anim.SetBool("Idle",false);
            }
        }

        if(IsGrounded() && Input.GetButtonDown("Jump"))
        {
            anim.SetBool("Jump",true);
            rb.velocity = new Vector2(rb.velocity.y, upForce);
        }
        else
        {
            anim.SetBool("Jump",false);
        }

        

    }
    
    private bool IsGrounded()
        {
            float extraHeightText = .1f;
            RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider2d.bounds.center, capsuleCollider2d.bounds.size, 0f, Vector2.down, extraHeightText, groundLayerMask);
            Color rayColor;
            if(raycastHit.collider != null)
            {
                rayColor = Color.green;
            }
            else
            {
                rayColor = Color.red;
            }
            Debug.DrawRay(capsuleCollider2d.bounds.center + new Vector3(capsuleCollider2d.bounds.extents.x, 0), Vector2.down * (capsuleCollider2d.bounds.extents.y + extraHeightText), rayColor);
            Debug.DrawRay(capsuleCollider2d.bounds.center - new Vector3(capsuleCollider2d.bounds.extents.x, 0), Vector2.down * (capsuleCollider2d.bounds.extents.y + extraHeightText), rayColor);
            Debug.DrawRay(capsuleCollider2d.bounds.center - new Vector3(capsuleCollider2d.bounds.extents.x, capsuleCollider2d.bounds.extents.y + extraHeightText), Vector2.right * (capsuleCollider2d.bounds.extents.x * 2), rayColor);
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
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            coins = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("coin"))
        {
            coins++;
            Destroy(other.gameObject);
            coinsText.text = coins.ToString("0");
        }
    }
}
