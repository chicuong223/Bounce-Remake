using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainMaceScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void FixedUpdate()
    {
        var playerPos = player.transform.position;
        var pos = transform.position;
        if (Mathf.Abs(pos.x - playerPos.x) <= 2.5)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}