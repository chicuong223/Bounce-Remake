using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]
    private string nextSceneName;

    [SerializeField]
    private bool destroyLevelManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Finish"))
        {
            if (destroyLevelManager)
            {
                LevelManager.Instance = null;
                SceneManager.LoadScene(nextSceneName);
            }
            //SceneManager.LoadScene(nextSceneID);
            else if (LevelManager.Instance != null)
            {
                LevelManager.Instance.LoadScene(nextSceneName);
            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}