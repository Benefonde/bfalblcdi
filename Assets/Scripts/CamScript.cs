using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    void Start()
    {
        sensitivity = PlayerPrefs.GetInt("sensitivity", 20) * 10;
        SwitchState(State.FirstPerson);
    }

    void Update()
    {
        sensitivity = PlayerPrefs.GetInt("sensitivity", 20);

        Vector2 r = new Vector2(ps.rootate.x, ps.rootate.y) * sensitivity * Time.deltaTime;

        yRotation += r.x;
        xRotation -= r.y;

        if (state == State.ThirdPerson)
        {
            xRotation = Mathf.Clamp(xRotation, 5f, 40f);
        }
        if (state == State.FirstPerson)
        {
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        }

        if (state != State.Cutscene)
        {
            player.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    void SwitchState(State stateToDoLol)
    {
        state = stateToDoLol;
        if (state != State.Cutscene)
        {
            gc.CursorLock(true);
        }
        else
        {
            gc.CursorLock(false);
        }
    }
    public void SwitchPerspective()
    {
        if (state == State.FirstPerson)
        {
            SwitchState(State.ThirdPerson);
        }
        else if (state == State.ThirdPerson)
        {
            SwitchState(State.FirstPerson);
        }
    }

    public void LMB()
    {
        RaycastHit h;

        if (Physics.Raycast(transform.position, transform.forward, out h, 5f))
        {
            if (h.transform.name == "RMCButton")
            {
                hand.SetTrigger("HIT");
                if (FindObjectsOfType<ContestantScript>().Length < 2)
                {
                    return;
                }
                for (int i = 0; i < FindObjectsOfType<ContestantScript>().Length; i++)
                {
                    if (!FindObjectsOfType<ContestantScript>()[i].player)
                    {
                        Destroy(FindObjectsOfType<ContestantScript>()[i].gameObject);
                    }
                }
                h.transform.gameObject.GetComponent<Animator>().SetTrigger("Press");
                h.transform.gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }

    void LateUpdate()
    {
        if (state == State.FirstPerson)
        {
            transform.position = player.position + Vector3.up * (player.Find("Face").localPosition.y + 0.2f);
        }
        if (state == State.ThirdPerson)
        {
            transform.position = player.position + player.forward * -6f + Vector3.up * (player.Find("Face").localPosition.y + 2);
        }
    }

    enum State
    {
        FirstPerson,
        ThirdPerson,
        Cutscene
    }

    State state;

    public GameController gc;

    public float sensitivity;
    public Transform player;
    public ContestantScript ps;

    float xRotation;
    float yRotation;

    public Animator hand;

    public AudioClip pop;
}
