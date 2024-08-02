using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContestantStatApply : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("Contestant", 0) != 0)
        {
            c = contestants[PlayerPrefs.GetInt("Contestant") - 1];
        }
        else
        {
            c = contestants[Random.Range(0, contestants.Length - 1)];
        }
        print($"{c.name} spawned in");
        transform.name = c.name;
        sprRenderer.sprite = c.body;
        arms.SetActive(c.arms);
        cCollider.height = c.collision[1];
        cCollider.radius = c.collision[0];
        cCollider.center = new Vector3(0, c.collision[2], 0);
        cImage.sprite = c.body;
        stats[0].text = c.speed.ToString();
        stats[1].text = c.jumpStrength.ToString();
        stats[2].text = c.gravity.ToString();
        noArms.SetActive(!c.arms);
        if (c.name == "David")
        {
            transform.Find("Arms").gameObject.SetActive(false);
            transform.Find("Face").gameObject.SetActive(false);
            transform.Find("Legs").gameObject.SetActive(false);
            return;
        }
        transform.Find("Body").position = c.bodyOffset;
        transform.Find("Arms").position = c.armsOffset;
        transform.Find("Face").position = c.faceOffset;
        transform.Find("Face").localScale = new Vector3(c.faceSize, c.faceSize, c.faceSize);
        transform.Find("FaceButBehind").position = c.faceOffset;
        transform.Find("FaceButBehind").localScale = new Vector3(c.faceSize, c.faceSize, c.faceSize);
        transform.Find("Legs").position = c.legsOffset;
        transform.Find("Arms").Find("Left Arm").localPosition = new Vector3(-c.ArmX, 0, 0);
        transform.Find("Arms").Find("Right Arm").localPosition = new Vector3(c.ArmX, 0, 0);
        transform.Find("Legs").Find("Right Leg").localPosition = new Vector3(-c.LegX, 0, 0);
        transform.Find("Legs").Find("Left Leg").localPosition = new Vector3(c.LegX, 0, 0);
    }

    public BfdiContestant[] contestants = new BfdiContestant[21]; // Alphabetical order

    public BfdiContestant c;

    public Image cImage;
    public TMP_Text[] stats; // 0 spd 1 jmpstr 2 grvty
    public GameObject noArms;

    public SpriteRenderer sprRenderer;
    public GameObject arms;
    public CapsuleCollider cCollider;
}
