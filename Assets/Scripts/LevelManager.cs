using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField]
    private GameObject loadingPanel;

    private string targetSceneName;

    public float MinLoadTime;

    [SerializeField]
    private TextMeshProUGUI levelText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        loadingPanel.SetActive(false);
    }

    public void LoadScene(string sceneName)
    {
        targetSceneName = sceneName;
        levelText.text = sceneName;
        StartCoroutine(LoadSceneRoutine());
    }

    private IEnumerator LoadSceneRoutine()
    {
        loadingPanel.SetActive(true);
        AsyncOperation op = SceneManager.LoadSceneAsync(targetSceneName);
        float elapsedTime = 0f;
        while (!op.isDone)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        while (elapsedTime < MinLoadTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        loadingPanel.SetActive(false);
    }
}