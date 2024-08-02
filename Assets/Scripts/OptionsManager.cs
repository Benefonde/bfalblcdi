using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    void Start()
    {
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        switch (PlayerPrefs.GetInt("fullscreen", 1))
        {
            case 0: fullscreen.isOn = false; Screen.fullScreen = false; break;
            case 1: fullscreen.isOn = true; Screen.fullScreen = true; break;
        }
        switch (PlayerPrefs.GetInt("freeroam", 0))
        {
            case 0: freeroam.isOn = false; break;
            case 1: freeroam.isOn = true; break;
        }
        switch (PlayerPrefs.GetInt("funy", 0))
        {
            case 0: funny.isOn = false; break;
            case 1: funny.isOn = true; break;
        }
        sensitivity.value = PlayerPrefs.GetInt("sensitivity", 20);
    }

    void Update()
    {
        if (fullscreen.isOn)
        {
            Screen.fullScreen = true;
            PlayerPrefs.SetInt("fullscreen", 1);
        }
        else
        {
            Screen.fullScreen = false;
            PlayerPrefs.SetInt("fullscreen", 0);
        }
        if (freeroam.isOn)
        {
            PlayerPrefs.SetInt("freeroam", 1);
        }
        else
        {
            PlayerPrefs.SetInt("freeroam", 0);
        }
        if (funny.isOn)
        {
            PlayerPrefs.SetInt("funy", 1);
        }
        else
        {
            PlayerPrefs.SetInt("funy", 0);
        }
        PlayerPrefs.SetInt("sensitivity", Mathf.RoundToInt(sensitivity.value));
    }

    public Toggle fullscreen;
    public Toggle freeroam;
    public Toggle funny;
    public Slider sensitivity;
}