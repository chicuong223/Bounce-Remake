using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject configCanvas;

    private void Start()
    {
        configCanvas.SetActive(false);
    }

    public void OpenConfigMenu()
    {
        configCanvas.SetActive(true);
    }

    public void CloseConfigMenu()
    {
        configCanvas.SetActive(false);
    }

    public void Play(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void Exit()
    {
        Application.Quit();
    }
}