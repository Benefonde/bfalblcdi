using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CursorMenuGamepad : MonoBehaviour
{
    void Start()
    {
        c = GetComponent<Canvas>();
        cRt = c.GetComponent<RectTransform>();
        cm = new CursorMenu();
        cm.Enable();
        cursor.gameObject.SetActive(true);
        SetControls();
    }

    void SetControls()
    {
        cm.MenuControls.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        cm.MenuControls.Move.canceled += ctx => move = Vector2.zero;
    }

    void Update()
    {
        cursor.Translate(move);
        cursor.localPosition = new Vector2(
        Mathf.Clamp(cursor.localPosition.x, 0, cRt.sizeDelta.x - cRt.sizeDelta.x), Mathf.Clamp(cursor.localPosition.y, -cRt.sizeDelta.y + cRt.sizeDelta.y, 0));
    }

    public RectTransform cursor;
    CursorMenu cm;
    Canvas c;
    RectTransform cRt;

    Vector2 move;
}
