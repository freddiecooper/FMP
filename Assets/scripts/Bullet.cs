using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 4);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        assultRifleEnemy enemy = hitInfo.GetComponent<assultRifleEnemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);

        pistolEnemy pEnemy = hitInfo.GetComponent<pistolEnemy>();
        if(pEnemy != null)
        {
            pEnemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
