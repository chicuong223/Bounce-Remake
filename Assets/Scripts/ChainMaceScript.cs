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

    private AudioSource audioSource;

    private Vector3 originalPosition;

    [SerializeField] private float despawnDistance;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        audioSource = GetComponent<AudioSource>();
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

        if (isDespawned)
        {
            if (Mathf.Abs(transform.position.y - originalPosition.y) >= despawnDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    //private void Update()
    //{
    //    if (isDespawned)
    //    {
    //        StartCoroutine(despawn());
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            audioSource.Play();
        }
    }

    //private IEnumerator despawn()
    //{
    //    if (isGrounded())
    //    {
    //        yield return new WaitForSeconds(timeToDespawn);
    //        rb.bodyType = RigidbodyType2D.Static;
    //        transform.position = originalPosition;
    //    }
    //    else
    //    {
    //        yield return null;
    //    }
    //}

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