using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    //private BallMovement ball;

    [SerializeField]
    private int score;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        //ball = BallMovement.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            BallMovement.score += score;
            //GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
            //gameObject.GetComponent<AudioSource>().Play();
            //Debug.Log(ball.score);
            scoreText.text = $"Score: {BallMovement.score}";
            Destroy(gameObject);
        }
    }
}