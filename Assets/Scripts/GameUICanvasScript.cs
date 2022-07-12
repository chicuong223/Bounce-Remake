using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUICanvasScript : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI livesText;

    [SerializeField]
    private TextMeshProUGUI timeText;

    // Start is called before the first frame update
    private void Start()
    {
        scoreText.text = $"Score: {BallMovement.score}";
        livesText.text = $"Lives: {BallMovement.Lives}";
        timeText.text = $"Time: 00:00";
    }

    // Update is called once per frame
    private void Update()
    {
        var time = TimeSpan.FromSeconds(LevelManager.time);
        timeText.text = string.Format("Time: {0:00}:{1:00}", time.Minutes, time.Seconds);
    }
}