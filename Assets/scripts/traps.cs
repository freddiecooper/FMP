using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class traps : MonoBehaviour
{
    public int playerDamage = 100;
    public Rigidbody2D rb;
    public string game;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playercontroller player = hitInfo.GetComponent<playercontroller>();
        if(player != null)
        {
            player.TakeDamage(playerDamage);
            SceneManager.LoadScene(game);
        }
    }
}
