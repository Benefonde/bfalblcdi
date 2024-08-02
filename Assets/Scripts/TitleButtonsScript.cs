using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButtonsScript : MonoBehaviour
{
    public void StartAsCharacter(int character)
    {
        PlayerPrefs.SetInt("Contestant", character);
        if (PlayerPrefs.GetInt("funy", 0) == 1)
        {
            PlayerPrefs.SetInt("Contestant", 5);
        }
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