using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private GameObject configMenuCanvas;

    private int initialScore;

    private int initialLives;

    private Scene currentScene;

    private bool isPaused = false;

    private void Start()
    {
        initialScore = BallMovement.Score;
        initialLives = BallMovement.Lives;
        currentScene = SceneManager.GetActiveScene();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }

    public void OpenConfigMenu()
    {
        configMenuCanvas.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if (isPaused) Pause();
        else Resume();
    }

    public void ReloadLevel()
    {
        BallMovement.Score = initialScore;
        BallMovement.Lives = initialLives;
        if (LevelManager.Instance != null)
            LevelManager.Instance.LoadScene(currentScene.name);
        else
            SceneManager.LoadScene(currentScene.buildIndex);
    }
}