﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

    public float fireRate = 0.1f;
    public Transform firePoint;
    public GameObject bulletPrefab;

    bool touching = false;

    float timeUntilFire;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1") && timeUntilFire < Time.time && touching)
        {
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }

    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
            if(other.gameObject.CompareTag("Player"))
            {
                if(touching == false)
                {
                    touching = true;
                }
            }
            /*else
            {
                if(touching == true)
                {
                    touching = false;
                }
            }*/
    }

    /*private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
            {
                touching = false;

                if(touching == true)
                {
                    touching = false;
                }
            }
    }*/
}
