using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    public Transform A_equipPosition;
    public Transform P_equipPosition;
    GameObject currentWeapon;
    BoxCollider collider;

    bool canGrab_A;
    bool canGrab_P;

    void Start()
    {
        collider = currentWeapon.GetComponent<BoxCollider>();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Z))
        {
            currentWeapon.transform.parent = null;
            collider.isTrigger = false;

            if (!currentWeapon.GetComponent<Rigidbody2D>())
                currentWeapon.AddComponent<Rigidbody2D>();
        }

        if (canGrab_A)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                PickUp_A();
            }
        }

        if (canGrab_P)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                PickUp_A();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("assultrifle"))
        {
            currentWeapon = other.gameObject;
            canGrab_A = true;
        }
        else
        {
            canGrab_A = false;
        }

        if(other.gameObject.CompareTag("pistol"))
        {
            currentWeapon = other.gameObject;
            canGrab_P = true;
        }
        else
        {
            canGrab_P = false;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        
    }*/

    private void PickUp_A()
    {
        currentWeapon.transform.position = A_equipPosition.position;
        currentWeapon.transform.parent = A_equipPosition;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        Debug.Log("picked up");
    }

    private void PickUp_P()
    {
        currentWeapon.transform.position = P_equipPosition.position;
        currentWeapon.transform.parent = P_equipPosition;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        Debug.Log("picked up");
    }
}
