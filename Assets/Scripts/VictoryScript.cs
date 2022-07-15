using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI VictoryText;
    private Color lerpedColor = Color.white;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI totalScoreText;
    [SerializeField] private int lifeScore;

    private int highScore = 0;
    private int totalScore = 0;

    private void Start()
    {
        /* Get high score */
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
        }
        else
        {
            highScore = 0;
        }
        totalScore = BallMovement.Score + lifeScore * BallMovement.Lives;
        scoreText.text = $"Your Score: {BallMovement.Score}";
        livesText.text = $"Remaining Lives: {BallMovement.Lives}";
        highScoreText.text = $"High Score: {highScore}";
        totalScoreText.text = $"Total score: {BallMovement.Score} + {lifeScore} * {BallMovement.Lives} = {totalScore}";
        if (totalScore > highScore)
        {
            totalScoreText.text += " (New high score)";
            PlayerPrefs.SetInt("highScore", totalScore);
        }
    }

    private void Update()
    {
        lerpedColor = Color.Lerp(Color.red, Color.green, Mathf.PingPong(Time.time, 1));
        VictoryText.faceColor = lerpedColor;
    }

    public void ChangeScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}