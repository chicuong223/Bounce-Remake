using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingSpike : MonoBehaviour
{
    //Axes to move on
    public Vector3 MoveAxes = Vector2.zero;

    //Distance to travel
    public float Distance = 5f;

    //Original position
    private Vector3 OrigPos = Vector3.zero;

    private void Start()
    {
        //Copy original position
        OrigPos = transform.position;
    }

    private void Update()
    {
        //Update platform position with ping pong
        transform.position = OrigPos + MoveAxes * Mathf.PingPong(Time.time, Distance);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.collider.transform.parent == null)
            {
                collision.collider.transform.SetParent(transform);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(null);
        }
    }
}