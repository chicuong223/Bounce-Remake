using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1AudioScript : MonoBehaviour
{
    [SerializeField] private AudioClip levelAudioClip;

    // Start is called before the first frame update
    private void Start()
    {
        var levelAudio = AudioScript.Instance;
        if (levelAudio == null)
        {
            GameObject levelAudioObj = new GameObject();
            levelAudioObj.name = "LevelAudio";
            levelAudioObj.AddComponent<AudioScript>();
            var audioSource = levelAudioObj.AddComponent<AudioSource>();
            audioSource.clip = levelAudioClip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}