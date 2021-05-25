using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shop : MonoBehaviour
{
    public Transform buyPoint;
    public GameObject weaponPrefab;

    private bool canBuy = false;

    void Start()
    {

    }

    void Update()
    {
        if(canBuy && playercontroller.coins >= 4)
        {
            if(Input.GetKeyDown("b"))
            {
                weaponDrop();
                playercontroller.coins -= 4;
                playercontroller.coinsText.text = playercontroller.coins.ToString("0");
            }
        }
    }

    /*private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && (playercontroller.coins >= 4))
        {
            Debug.Log("touching");
            if(Input.GetKeyDown("b"))
            {
                weaponDrop();
            }
            
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            canBuy = true; 
            Debug.Log("canBuy");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            canBuy = false;
            Debug.Log("cantBuy");
        }
    }

    void weaponDrop()
    {
        Instantiate(weaponPrefab, buyPoint.position, buyPoint.rotation);
    }
}
