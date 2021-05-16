using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{

    public Transform buyPoint;
    public GameObject coinPrefab;
    public static int  Coins;

    void Start()
    {
        Coins = playercontroller.coins;
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && Coins >=4)
        {
            Debug.Log("touching");
            if(Input.GetKey ("b"))
            {
                weaponDrop();
            }
            
        }
    }

    void weaponDrop()
    {
        Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
        Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
        Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
        Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
        Instantiate(coinPrefab, buyPoint.position, buyPoint.rotation);
    }
}
