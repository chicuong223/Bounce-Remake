using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainMaceScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject player;
    private CircleCollider2D circleCollider;

    [SerializeField] private bool isDespawned;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField] private float timeToDespawn = 5f;

    private Vector3 originalPosition;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        originalPosition = transform.position;
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void FixedUpdate()
    {
        var playerPos = player.transform.position;
        var pos = transform.position;
        if (Mathf.Abs(pos.x - playerPos.x) <= 2.5 && pos.y > playerPos.y)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void Update()
    {
        if (isDespawned)
        {
            StartCoroutine(despawn());
        }
    }

    private IEnumerator despawn()
    {
        if (isGrounded())
        {
            yield return new WaitForSeconds(timeToDespawn);
            rb.bodyType = RigidbodyType2D.Static;
            transform.position = originalPosition;
        }
        else
        {
            yield return null;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit =
            Physics2D.BoxCast(circleCollider.bounds.center, circleCollider.bounds.size, 0, Vector2.down, .2f, groundLayer);
        return raycastHit.collider != null;
        //Collider2D collider = collision.collider;
        //Vector3 contactPoint = collision.contacts[0].point;
        //Vector3 center = collider.bounds.center;

        //bool top = contactPoint.y >= center.y;
        //return top;
    }
}