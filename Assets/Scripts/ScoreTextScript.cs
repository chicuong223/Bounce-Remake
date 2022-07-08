using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    private Text scoreText;
    //private BallMovement ball;

    // Start is called before the first frame update
    private void Start()
    {
        scoreText = GetComponent<Text>();
        //ball = BallMovement.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
        //scoreText.text = $"Score: {ball.score}";
        //Debug.Log(ball.score);
    }
}