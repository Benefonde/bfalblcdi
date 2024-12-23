using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            string[] a = { "MY NAME IS COINY.               I don't know what I'm doing!", "hrngnrhngngnrhngnggnrhnghnnhrnrnn. nhrnnrnhrhrrhnrhnrhnrnhnhrhrnrhrnhnrhrnhrnhngn.", "Are you okay?" };
            StartCoroutine(NewDialogue(a, b));
        }
    }

    public IEnumerator NewDialogue(string[] sayThis, Sprite[] charSprites)
    {
        if (dialogueOngoing)
        {
            yield break;
        }
        anim.SetTrigger("up");
        dialogueOngoing = true;
        arrow.SetActive(false); 
        charImage.sprite = charSprites[0];
        txt.text = string.Empty;
        yield return new WaitForSeconds(1f);
        FindObjectOfType<GameController>().CursorLock(false);
        for (int i = 0; i < sayThis.Length; i++)
        {
            continueDialogue = false;
            charImage.sprite = charSprites[i];
            txt.text = string.Empty;
            arrow.SetActive(false);
            char[] c = sayThis[i].ToCharArray();
            for (int rr = 0; rr < c.Length; rr++) // "rr" is this because rrAAAAAAGH
            {
                txt.text += c[rr];
                if (!Input.GetMouseButton(0))
                {
                    switch (c[rr].ToString())
                    {
                        default: yield return new WaitForSeconds(0.01667f); break;
                        case "?": yield return new WaitForSeconds(0.2f); break;
                        case "!": yield return new WaitForSeconds(0.2f); break;
                        case ".": yield return new WaitForSeconds(0.2f); break;
                        case ",": yield return new WaitForSeconds(0.1f); break;
                    }
                }
            }
            yield return new WaitForSeconds(1.5f);
        }
        anim.SetTrigger("down");
        dialogueOngoing = false;
        FindObjectOfType<GameController>().CursorLock(true);
    }

    public void Click()
    {
        continueDialogue = true;
    }

    [SerializeField]
    Image charImage;
    [SerializeField]
    TMP_Text txt;
    public GameObject arrow;

    [SerializeField]
    bool dialogueOngoing;

    Animator anim;

    public Sprite[] b;

    bool continueDialogue;
}
