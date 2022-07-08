using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesTextScript : MonoBehaviour
{
    private Text livesText;
    private BallMovement ball;

    // Start is called before the first frame update
    private void Start()
    {
        livesText = GetComponent<Text>();
        //ball = BallMovement.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
        livesText.text = $"Lives: {BallMovement.Lives}";
    }
}