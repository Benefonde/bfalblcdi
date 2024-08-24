using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CursorMenuGamepad : MonoBehaviour
{
    void Start()
    {
        c = GetComponent<Canvas>();
        cm = new CursorMenu();
        cm.Enable();
        SetControls();
    }

    void SetControls()
    {
        cm.MenuControls.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        cm.MenuControls.Move.canceled += ctx => move = Vector2.zero;

        cm.MenuControls.Confirm.performed += ctx => Click();
    }

    void Click()
    {

    }


    void Update()
    {
        if (Gamepad.all.Count > 0)
        {
            pos += move;
            pos += Mouse.current.delta.ReadValue();
            Mouse.current.WarpCursorPosition(pos);
        }
    }

    CursorMenu cm;
    Canvas c;

    Vector2 move;
    Vector2 pos;
}
