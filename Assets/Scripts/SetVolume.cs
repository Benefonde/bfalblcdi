using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat("MasterVol", Mathf.Log10(PlayerPrefs.GetFloat("masterV")) * 20);
        mixer.SetFloat("MusicVol", Mathf.Log10(PlayerPrefs.GetFloat("musicV")) * 20);
        mixer.SetFloat("SoundVol", Mathf.Log10(PlayerPrefs.GetFloat("soundV")) * 20);
        mixer.SetFloat("VoiceVol", Mathf.Log10(PlayerPrefs.GetFloat("voiceV")) * 20);
    }

    public AudioMixer mixer;
}
