using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf)
            {
                CursorLock(false);
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                CursorLock(true);
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(contestantAngry, new Vector3(0, -0.3045744f, 0), Quaternion.identity);
            switch (player.name)
            {
                case "Pin": aud.PlayOneShot(pinScream); break;
                case "Firey": aud.PlayOneShot(fireyScream); break;
                case "Golf Ball": aud.PlayOneShot(gbScream); break;
                case "Tennis Ball": aud.PlayOneShot(tbScream); break;
                case "Ice Cube": aud.PlayOneShot(icScream); break;
                case "Woody": aud.PlayOneShot(woodyScream); break;
                case "Teardrop": break;
                default: aud.PlayOneShot(genericScream); break;
            }
        }
        
        if (!aud.isPlaying)
        {
            aud.PlayOneShot(music[Random.Range(0, music.Length - 1)]);
        }
    }

    public void CursorLock(bool b)
    {
        if (b)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void AddPoints(ContestantScript contestant, int points)
    {
        contestant.points += 10;
        if (contestant.player)
        {
            pointsAnimationText[0].text = $"+{points}";
            pointsAnimationText[1].text = $"+{points}";
            pointsAnimationText[1].color = new Color(0.5f, 0, 0, 1);
            if (points > -1)
            {
                pointsAnimationText[0].text = $"-{Mathf.Abs(points)}";
                pointsAnimationText[1].text = $"-{Mathf.Abs(points)}";
                pointsAnimationText[1].color = new Color(0, 0.5f, 0, 1);
            }
            pointsAnimator.SetTrigger("pointsGet");
        }
    }

    public GameObject pauseMenu;

    public ContestantScript player;

    public AudioClip genericScream;
    public AudioClip pinScream;
    public AudioClip gbScream;
    public AudioClip tbScream;
    public AudioClip woodyScream;
    public AudioClip fireyScream;
    public AudioClip icScream;

    public Animator pointsAnimator;
    public TMP_Text[] pointsAnimationText;

    AudioSource aud;
    public AudioClip[] music;

    public GameObject contestantAngry;
}
