using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain : MonoBehaviour
{

    public Material mat;
    public Rigidbody2D origin;
    public float line_width = .1f;
    public float speed = 0.1f;

    private LineRenderer line;
    private Vector3 velocity;


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
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, origin.position);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        velocity = Vector2.zero;
    }
}
