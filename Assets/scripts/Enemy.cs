﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int playerDamage = 20;
    public int health = 100;
    public float Range;
    public Transform Target;
    public GameObject DetectLight;
    public GameObject Gun;
    public GameObject Bullet;
    public float fireRate = 0.3f;
    public Transform firePoint;

    bool Detected = false;

    float timeUntilFire;

    Vector2 Direction;

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
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;
        
        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Direction, Range);

        if(raycastHit)
        {
            if(raycastHit.collider.gameObject.tag == "Player")
            {
                if(Detected == false)
                {
                    Detected = true;
                    DetectLight.GetComponent<SpriteRenderer>().color = Color.red;
                }
            }

            else
            {
                if(Detected == true)
                {
                    Detected = false;
                    DetectLight.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }

        if(Detected)
        {
            Gun.transform.up = Direction;
            if (timeUntilFire < Time.time)
            {
                Shoot();
                timeUntilFire = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        Instantiate(Bullet, firePoint.position, firePoint.rotation);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,Range);
    }
}
