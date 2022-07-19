using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifePickupScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;
    private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag.Equals("Player"))
            {
                BallMovement.Lives += 1;
                livesText.text = $"Lives: {BallMovement.Lives}";
                //Destroy(gameObject);
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<CircleCollider2D>().enabled = false;
                audioSource.Play();
                StartCoroutine(DestroyPickup());
            }
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator DestroyPickup()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}