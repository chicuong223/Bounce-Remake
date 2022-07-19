using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask playerLayer;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private CircleCollider2D circleCollider;
    [SerializeField] private Vector2 maxPoint;
    [SerializeField] private Vector2 minPoint;
    [SerializeField] private int lives;
    [SerializeField] private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    private Animator animator;
    [SerializeField] private Vector2 bounceForce; //how much to bounce after player stomping on enemy
    [System.NonSerialized] public bool isKilled;
    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        isKilled = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var pos = transform.localPosition;
        pos.x += speed * Time.deltaTime;
        transform.localPosition = pos;
        //flip();
        //rb.velocity = new Vector2(speed, rb.velocity.y);
        //rotate facing of enemy

        if (transform.position.x <= minPoint.x || transform.position.x >= maxPoint.x)
        {
            flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isUnderPlayer())
            {
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = bounceForce;
                lives--;
                animator.SetTrigger("Hurt");
                audioSource.Play();
                if (lives <= 0)
                {
                    BallMovement.Score += score;
                    scoreText.text = $"Score: {BallMovement.Score}";
                    //Destroy(gameObject);
                    circleCollider.enabled = false;
                    boxCollider.enabled = false;
                    GetComponent<SpriteRenderer>().enabled = false;
                    isKilled = true;
                    StartCoroutine(DestroyMonster());
                }
            }
            else
            {
                collision.gameObject.GetComponent<BallMovement>().Kill();
            }
        }
        else if (collision.gameObject.CompareTag("Monster"))
        {
            flip();
        }
    }

    private bool isUnderPlayer()
    {
        RaycastHit2D raycastHit =
            Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.up, 0.2f, playerLayer);
        return raycastHit.collider != null;
    }

    private void flip()
    {
        speed = -speed;
        //flip();
        //rb.velocity = new Vector2(speed, rb.velocity.y);
        //rotate facing of enemy
        if (speed > 0f)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private IEnumerator DestroyMonster()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}