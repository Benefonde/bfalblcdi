using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiSizer : MonoBehaviour
{
    void Start()
    {
        c = GetComponent<CanvasScaler>();
        if (c.uiScaleMode == CanvasScaler.ScaleMode.ConstantPixelSize)
        {
            c.scaleFactor = PlayerPrefs.GetInt("guiScale", 2);
        }
    }

    void Update()
    {
        if (c.uiScaleMode == CanvasScaler.ScaleMode.ConstantPixelSize)
        {
            c.scaleFactor = PlayerPrefs.GetInt("guiScale", 2);
        }
    }

    CanvasScaler c;
}
