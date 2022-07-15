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

    // Start is called before the first frame update
    private void Start()
    {
        scoreText.text = $"Score: {BallMovement.Score}";
        livesText.text = $"Lives: {BallMovement.Lives}";
    }
}