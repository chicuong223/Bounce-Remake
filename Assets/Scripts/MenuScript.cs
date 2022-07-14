using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Play(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void Exit()
    {
        Application.Quit();
    }
}