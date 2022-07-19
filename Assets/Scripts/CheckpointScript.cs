using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    [System.NonSerialized]
    public AudioSource m_AudioSource;

    [System.NonSerialized]
    public bool isHit = false;

    // Start is called before the first frame update
    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
}