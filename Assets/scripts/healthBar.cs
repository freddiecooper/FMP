using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    public Slider healthbar;
    playercontroller playerHealth;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>();
    }

    void Update()
    {
        healthbar.value = playerHealth.health;
    }
}
