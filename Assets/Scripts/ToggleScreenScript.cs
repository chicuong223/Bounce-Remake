using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScreenScript : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Fullscreen()
    {
        if (!Screen.fullScreen)
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }

    public void Windowed()
    {
        //if (Screen.fullScreen) Screen.fullScreen = false;
        if (Screen.fullScreen)
        {
            Screen.SetResolution(960, 540, false);
        }
    }

    public void CloseConfigMenu()
    {
        gameObject.SetActive(false);
    }
}