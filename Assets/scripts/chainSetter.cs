using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainSetter : MonoBehaviour
{
    public Chain chain;

    void Start()
    {
        
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            chain.setStart(worldPos);
        }
    }
}
