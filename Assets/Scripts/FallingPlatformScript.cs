using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private float originalHeight;
    [SerializeField] private float despawnHeight;
    private Vector3 originalPosition;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalHeight = transform.position.y;
        originalPosition = transform.position;
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.transform.position.y > transform.position.y)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.y - originalHeight) >= despawnHeight)
        {
            rb.bodyType = RigidbodyType2D.Static;
            transform.position = originalPosition;
        }
    }
}