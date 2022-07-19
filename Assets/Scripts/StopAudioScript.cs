using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAudioScript : MonoBehaviour
{
    [SerializeField] private string audioGameObjectName;

    private void Awake()
    {
        if (AudioScript.Instance != null)
        {
            AudioScript.Instance = null;
        }
        var audio = GameObject.Find(audioGameObjectName);
        if (audio != null) Destroy(audio);
    }
}