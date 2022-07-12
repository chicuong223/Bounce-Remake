using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool CanInflate = true;

    //private bool CanJump = true;
    private float buttonTime = 0.3f;

    private float jumpTime;
    private bool jumping;
    private bool jumpCancelled;
    private float cancelRate = 100;

    public static int Lives = 30;

    public Vector2 ballPosition;
    public bool isCheckpoint = false;
    public static int score = 0;
    private CircleCollider2D circleCollider;

    [SerializeField]
    private TextMeshProUGUI livesText;

    public LayerMask groundLayer;

    [SerializeField]
    private AudioClip jumpClip;

    [SerializeField]
    private AudioClip inflateClip;

    [SerializeField]
    private AudioClip deadClip;

    //public AudioSource audioSource;
    private float deathHeight = -40f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CanInflate = true;
        //audioSource = GetComponent<AudioSource>();
        //audioSource.enabled = true;
        //ballPosition = transform.position;
    }

    private void Awake()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Checkpoint"))
        {
            var checkpoint = collision.gameObject.transform.position;
            ballPosition = checkpoint;
            isCheckpoint = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Jump();
        DeadFall();
        //if (Lives <= 0)
        //{
        //    SceneManager.LoadScene("GameOver");
        //}
    }

    private void Move()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var pos = transform.position;
        transform.Rotate(Vector3.forward * (-h) * 300 * Time.deltaTime);
        pos.x += h * speed * Time.deltaTime;
        transform.position = pos;
    }

    private void FixedUpdate()
    {
        Move();
        if (jumpCancelled && jumping && rb.velocity.y > 0)
        {
            rb.AddForce(Vector2.down * cancelRate);
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit =
            Physics2D.BoxCast(circleCollider.bounds.center, circleCollider.bounds.size, 0, Vector2.down, 0.2f, groundLayer);
        return raycastHit.collider != null;
        //Collider2D collider = collision.collider;
        //Vector3 contactPoint = collision.contacts[0].point;
        //Vector3 center = collider.bounds.center;

        //bool top = contactPoint.y >= center.y;
        //return top;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded())
            {
                float jumpAmount
                    = Mathf.Sqrt(jumpForce * -2 * (Physics2D.gravity.y * rb.gravityScale));
                rb.AddForce(new Vector2(0, jumpAmount), ForceMode2D.Impulse);
                jumping = true;
                jumpTime = 0;
                jumpCancelled = false;
                //CanJump = false;
            }
        }
        if (jumping)
        {
            jumpTime += Time.deltaTime;
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jumpCancelled = true;
            }
            if (jumpTime > buttonTime)
            {
                jumping = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Killer"))
        {
            Kill();
        }
        else if (collision.gameObject.tag.Equals("Pumper"))
        {
            //audioSource.clip = inflateClip;
            Inflate();
        }
        else if (collision.gameObject.tag.Equals("Deflate"))
        {
            //audioSource.clip = inflateClip;
            Deflate();
        }
        //else if (collision.gameObject.tag.Equals("Platform"))
        //{
        //    var isTop = CheckSideCollision(collision);
        //    if (isTop)
        //    {
        //        //audioSource.clip = jumpClip;
        //        CanJump = true;
        //    }
        //}
        //else
        //{
        //    CanJump = false;
        //}
        //audioSource.Play();
    }

    private void Kill()
    {
        //Destroy(gameObject);
        Lives -= 1;
        if (!CanInflate)
        {
            Deflate();
        }
        transform.position = ballPosition;
        livesText.text = $"Lives: {Lives}";
        //if(isCheckpoint)
        //{
        //    if(!CanInflate)
        //    {
        //        Deflate();
        //    }
        //    transform.position = ballPosition;
        //}
        //else
        //{
        //    Scene currentScene = SceneManager.GetActiveScene();
        //    SceneManager.LoadScene(currentScene.name);
        //}
    }

    private void DeadFall()
    {
        var pos = transform.position;
        if (pos.y <= deathHeight)
        {
            Kill();
        }
    }

    private void Inflate()
    {
        if (CanInflate)
        {
            var scale = transform.localScale;
            scale.x *= 2;
            scale.y *= 2;
            transform.localScale = scale;
            CanInflate = false;
            jumpForce *= 2;
        }
    }

    private void Deflate()
    {
        if (!CanInflate)
        {
            var scale = transform.localScale;
            scale.x /= 2;
            scale.y /= 2;
            transform.localScale = scale;
            CanInflate = true;
            jumpForce /= 2;
        }
    }
}