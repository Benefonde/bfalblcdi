using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveFile : MonoBehaviour
{
    void Start()
    {
        save = GetComponent<Save>();
    }

    Save save;

    public bool Title;

    public Image charImage;
    public TMP_Text saveNameText;
    public TMP_Text completionText;
    public TMP_Text statusText;
}
