using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistol : MonoBehaviour
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

        if (Input.GetButtonDown("Fire1") && timeUntilFire < Time.time)
        {
            if(pickUp.pickedUp_p)
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
