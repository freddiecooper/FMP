using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chainSetter : MonoBehaviour
{

    public Chain chain;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            chain.setStart(worldPos);
        }
    }
}
