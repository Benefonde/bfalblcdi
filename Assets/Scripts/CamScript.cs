﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    void Start()
    {
        sensetivity = PlayerPrefs.GetInt("sensetivity", 20) * 10;
        SwitchState(State.FirstPerson);
    }

    void Update()
    {
        InputCheck();

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensetivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensetivity / 1.2f;

        yRotation += mouseX;
        xRotation -= mouseY;

        if (state == State.ThirdPerson)
        {
            xRotation = Mathf.Clamp(xRotation, 5f, 40f);
        }
        if (state == State.FirstPerson)
        {
            xRotation = Mathf.Clamp(xRotation, -95f, 95f);
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
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
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
    }

    void LateUpdate()
    {

        if (state == State.FirstPerson)
        {
            transform.position = player.position + Vector3.up * (player.Find("Face").localPosition.y);
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

    public float sensetivity;
    public Transform player;

    float xRotation;
    float yRotation;
}