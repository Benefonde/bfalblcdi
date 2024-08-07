using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsManager : MonoBehaviour
{
    void Start()
    {
        CalculateMaxGuiScale();
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
        masterVolume.value = PlayerPrefs.GetFloat("masterV", 0.5f);
        musicVolume.value = PlayerPrefs.GetFloat("musicV", 1);
        soundVolume.value = PlayerPrefs.GetFloat("soundV", 1);
        voiceVolume.value = PlayerPrefs.GetFloat("voiceV", 1);
        guiScale.value = PlayerPrefs.GetInt("guiScale", 2);
    }

    void CalculateMaxGuiScale()
    {
        guiScale.maxValue = Mathf.Max(1, Mathf.Min(Mathf.FloorToInt(Screen.width / 215), Mathf.FloorToInt(Screen.height / 160)));
        print(guiScale.maxValue);
    }

    void Update()
    {
        CalculateMaxGuiScale();
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
        PlayerPrefs.SetInt("guiScale", Mathf.RoundToInt(guiScale.value));
        PlayerPrefs.SetFloat("masterV", masterVolume.value);
        PlayerPrefs.SetFloat("musicV", musicVolume.value);
        PlayerPrefs.SetFloat("soundV", soundVolume.value);
        PlayerPrefs.SetFloat("voiceV", voiceVolume.value);
        mixer.SetFloat("MasterVol", Mathf.Log10(masterVolume.value) * 20);
        mixer.SetFloat("MusicVol", Mathf.Log10(musicVolume.value) * 20);
        mixer.SetFloat("SoundVol", Mathf.Log10(soundVolume.value) * 20);
        mixer.SetFloat("VoiceVol", Mathf.Log10(voiceVolume.value) * 20);
    }

    public Toggle fullscreen;
    public Toggle freeroam;
    public Toggle funny;
    public Slider sensitivity;
    public Slider guiScale;

    public Slider masterVolume;
    public Slider musicVolume;
    public Slider soundVolume;
    public Slider voiceVolume;
    public AudioMixer mixer;
}