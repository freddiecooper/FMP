using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int playerDamage = 20;
    public int health = 100;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playercontroller player = hitInfo.GetComponent<playercontroller>();
        if(player != null)
        {
            player.TakeDamage(playerDamage);
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
