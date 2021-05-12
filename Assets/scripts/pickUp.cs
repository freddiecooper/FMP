using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{

    public Transform equipPosition;
    GameObject currentWeapon;

    bool canGrab;

    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (canGrab)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                PickUp();
            }
        }

        if(other.gameObject.CompareTag("weapon"))
        {
            Debug.Log("can pick up");
            currentWeapon = other.gameObject;
            canGrab = true;
        }
        else
        {
            canGrab = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private void PickUp()
    {
        currentWeapon.transform.position = equipPosition.position;
        currentWeapon.transform.parent = equipPosition;
        currentWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 90f);

        Debug.Log("picked up");
    }
}
