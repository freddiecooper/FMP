using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{

    public float speed;
    public float upForce;
    private BoxCollider2D boxCollider2d;

    private Rigidbody2D RB;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        RB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * speed, RB.velocity.y);

        if(IsGrounded() && Input.GetButtonDown("Jump"))
        {
            RB.velocity = new Vector2(RB.velocity.x, upForce);
        }
    }
    private bool IsGrounded()
        {
            float extraHeightText = .01f;
            RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeightText);
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
}
