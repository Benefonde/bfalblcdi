using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VersionText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        t[0].text = $"BFALBLCDI {Application.version}";
        t[1].text = $"BFALBLCDI {Application.version}";
    }

    public TMP_Text[] t;
}
