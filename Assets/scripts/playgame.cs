using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class playgame : MonoBehaviour
{

    public void LoadScene(string game)
    { 
         SceneManager.LoadScene(game);
    }

    public void LoadScene2(string menu)
    { 
         SceneManager.LoadScene(menu);
    }

    public void QuitGame ()
    {
         Debug.Log ("quit!");
         Application.Quit();
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
