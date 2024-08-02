using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Contestant", menuName = "Contestant")]
public class BfdiContestant : ScriptableObject
{
    public string contestantName; // Who is this
    public Vector3 bodyOffset; // Offsets
    public Vector3 legsOffset;
    public float LegX = 2.5f;
    public Vector3 faceOffset;
    public float faceSize = 0.3f;
    public Vector3 armsOffset;
    public float ArmX;
    public float[] collision = new float[3]; // 0 is width 1 is height 2 is Y center
    public Sprite body; // Image of the contestant
    public int speed; // How fast can they go [1.5x faster when running]
    public int jumpStrength; // How far can it jump
    public bool arms; // Do they have arms
    public string[] enemy;
    public string[] friend;
}
