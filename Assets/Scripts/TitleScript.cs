using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("saveNumber", 0);
        bg = GetComponent<Image>();
        bgAud = GetComponent<AudioSource>();
    }

    public void BgToFun(int saveNum)
    {
        PlayerPrefs.SetInt("saveNumber", saveNum);
        bg.color = new Color(1, 1, 1, 0.5f);
        bgAud.Play();
    }

    Image bg;

    AudioSource bgAud;
}
