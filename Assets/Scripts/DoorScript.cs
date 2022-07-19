using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private BoxCollider2D m_Collider;
    private SpriteRenderer m_SpriteRenderer;
    private Camera m_Camera;

    // Start is called before the first frame update
    private void Start()
    {
        m_Collider = GetComponent<BoxCollider2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.enabled = false;
        m_Collider.isTrigger = true;
        m_Camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_SpriteRenderer.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.transform.position.x > transform.position.x)
            {
                m_Collider.isTrigger = false;
                m_Camera.orthographicSize = 15;
            }
        }
    }
}