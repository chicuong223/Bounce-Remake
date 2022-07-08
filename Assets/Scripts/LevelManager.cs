using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static float time { get; set; }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
    }
}