using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firePoint;
    public GameObject bulletPrefab;

    bool touching = false;

    float timeUntilFire;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetButton("Fire1") && timeUntilFire < Time.time)
        {
            if(pickUp.pickedUp_a)
            {
                Shoot();
                timeUntilFire = Time.time + fireRate;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }


}
