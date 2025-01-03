﻿using System.Collections;
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
        InputCheck();

        sensitivity = PlayerPrefs.GetInt("sensitivity", 20) * 10;

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity / 1.2f;

        yRotation += mouseX;
        xRotation -= mouseY;

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

    void InputCheck()
    {
        if (Input.GetKeyDown(KeyCode.F5))
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
        
        if (Input.GetMouseButtonDown(0))
        {
            LMB();
        }
    }

    void LMB()
    {
        print("lmb");

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
        Debug.DrawRay(transform.position, transform.forward, Color.green, 1);
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

    float xRotation;
    float yRotation;

    public Animator hand;

    public AudioClip pop;
}
