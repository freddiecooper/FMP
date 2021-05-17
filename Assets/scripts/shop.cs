using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public Transform buyPoint;
    public GameObject weaponPrefab;

    void Start()
    {

    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && (playercontroller.coins >= 4))
        {
            Debug.Log("touching");
            if(Input.GetKey ("b"))
            {
                weaponDrop();
                playercontroller.coins -= 4;
            }
            
        }
    }

    void weaponDrop()
    {

        Instantiate(weaponPrefab, buyPoint.position, buyPoint.rotation);

        //Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
        //Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
        //Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
        //Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
        //Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
    }
}
