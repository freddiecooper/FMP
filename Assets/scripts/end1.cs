using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class end1 : MonoBehaviour
{

    public string Level2;

    //public void LoadScene(string Level2)
    //{ 
    //     SceneManager.LoadScene(Level2);
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(Level2);
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
