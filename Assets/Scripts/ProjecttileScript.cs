using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecttileScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private float destroyDistance = 20f;

    private Vector2 originalPosition;

    private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask playerLayer;

    private AudioSource audio;

    private void Start()
    {
        originalPosition = transform.position;
        boxCollider = GetComponent<BoxCollider2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void Update()
    {
        MoveProjectile();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isUnderPlayer())
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 15f);
                //Destroy(gameObject);
                audio.Play();
                boxCollider.enabled = false;
                GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(DestroyProjectile());
            }
            else
            {
                collision.gameObject.GetComponent<BallMovement>().Kill();
            }
        }
    }

    private void MoveProjectile()
    {
        //Move projectile

        if (transform.localScale.x == -1f)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        else if (transform.localScale.y == 1f)
        {
            transform.position += transform.right * speed * Time.deltaTime * -1;
        }

        //Distance between current position and original position
        var distance = Vector2.Distance(originalPosition, transform.position);

        if (distance > destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    private bool isUnderPlayer()
    {
        RaycastHit2D raycastHit =
            Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.up, 0.2f, playerLayer);
        return raycastHit.collider != null;
    }

    private IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}