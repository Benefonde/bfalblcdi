﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonsScript : MonoBehaviour
{
    public void StartAsCharacter(int character)
    {
        PlayerPrefs.SetInt("Contestant", character);
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToTitle()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title");
    }
}