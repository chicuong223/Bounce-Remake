using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeTextScript : MonoBehaviour
{
    private Text text;

    // Start is called before the first frame update
    private void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        var time = TimeSpan.FromSeconds(LevelManager.time);
        text.text = string.Format("Time: {0:00}:{1:00}", time.Minutes, time.Seconds);
    }
}