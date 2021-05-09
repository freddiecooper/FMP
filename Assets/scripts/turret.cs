using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{

    public float Range;
    public Transform Target;
    public GameObject DetectLight;

    bool Detected = false;

    Vector2 Direction;

    void Start()
    {
        
    }


    void Update()
    {
        Vector2 targetPos = Target.position;

        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position,Direction,Range);

        if(rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                if(Detected == false)
                {
                    Detected = true;
                    DetectLight.GetComponent<SpriteRenderer>().color = Color.red;
                    Debug.Log("hello");
                }
            }

            else
            {
                if(Detected == false)
                {
                    Detected = true;
                    DetectLight.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,Range);
    }
}
