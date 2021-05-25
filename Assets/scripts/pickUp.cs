using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    public Transform A_equipPosition;
    public Transform P_equipPosition;
    public static bool pickedUp_p = false;
    public static bool pickedUp_a = false;
    GameObject currentWeapon_P;
    GameObject currentWeapon_A;
    BoxCollider collider;

    bool canGrab_A;
    bool canGrab_P;

    void Start()
    {
        collider = currentWeapon_P.GetComponent<BoxCollider>();
        collider = currentWeapon_A.GetComponent<BoxCollider>();
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("hi");
            pickedUp_p = false;
            pickedUp_a = false;
            currentWeapon_P.transform.parent = null;
            currentWeapon_A.transform.parent = null;
            collider.isTrigger = false;
            
            if (!currentWeapon_A.GetComponent<Rigidbody2D>())
                currentWeapon_A.AddComponent<Rigidbody2D>();

            if (!currentWeapon_P.GetComponent<Rigidbody2D>())
                currentWeapon_P.AddComponent<Rigidbody2D>();
        }

        if (canGrab_A)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                PickUp_A();
                pickedUp_a = true;
                pickedUp_p = false;
                currentWeapon_P.transform.parent = null;
            }
            else
            {
                //pickedUp = false;
            }
        }

        if (canGrab_P)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                PickUp_P();
                pickedUp_p = true;
                pickedUp_a = false;
                currentWeapon_A.transform.parent = null;
            }
            else
            {
                //pickedUp = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("assultrifle"))
        {
            currentWeapon_A = other.gameObject;
            canGrab_A = true;
        }
        else
        {
            canGrab_A = false;
        }

        if(other.gameObject.CompareTag("pistol"))
        {
            currentWeapon_P = other.gameObject;
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
        currentWeapon_A.transform.position = A_equipPosition.position;
        currentWeapon_A.transform.parent = A_equipPosition;
        currentWeapon_A.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        Debug.Log("picked up");
    }

    private void PickUp_P()
    {
        currentWeapon_P.transform.position = P_equipPosition.position;
        currentWeapon_P.transform.parent = P_equipPosition;
        currentWeapon_P.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        Debug.Log("picked up");
    }
}
