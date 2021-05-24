using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{

    public Material mat;
    public Rigidbody2D origin;
    public float line_width = .1f;
    public float speed = 5f;
    public float pullForce = 10;

    private LineRenderer line;
    private Vector3 velocity;
    public bool pull = false;
    private bool update = false;


    void Start()
    {
        line = GetComponent<LineRenderer>();
        if (!line)
        {
            line = gameObject.AddComponent<LineRenderer>();
        }
        line.startWidth = line_width;
        line.endWidth = line_width;
        line.material = mat;
    }

    public void setStart(Vector2 targetPos)
    {
        Vector2 dir = targetPos - origin.position;
        dir = dir.normalized;
        velocity = dir * speed;
        transform.position = origin.position + dir;
        pull = false;
        update = true;
    }

    void Update()
    {

        if(!update)
        {
            return;
        }

        if(pull)
        {
            Vector2 dir = (Vector2)transform.position - origin.position;
            dir = dir.normalized;
            origin.AddForce(dir * pullForce);
        }
        if(Input.GetKey("space"))
        {
            transform.position = new Vector2 (20, 25);
        }
        else
        {
            transform.position += velocity * Time.deltaTime;
            float distance = Vector2.Distance(transform.position, origin.position);
            
            if(distance > 50 || Input.GetKey("space"))
            {
                update = false;
                line.SetPosition(0, Vector2.zero);
                line.SetPosition(1, Vector2.zero);
                transform.position = new Vector2 (20, 25);
                return;
            }
        }

        if(Input.GetKey("space") && pull)
        {
            transform.position = new Vector2 (20, 25);
        }

        if(Input.GetKey("space"))
        {
            update = false;
            line.SetPosition(0, Vector2.zero);
            line.SetPosition(1, Vector2.zero);
            pull = false;
            return;
            transform.position = new Vector2 (20, 25);
        }
        
        line.SetPosition(0, transform.position);
        line.SetPosition(1, origin.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        velocity = Vector2.zero;
        pull = true;
    }
}
