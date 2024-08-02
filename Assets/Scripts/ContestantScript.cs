using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ContestantScript : MonoBehaviour
{
    void Start()
    {
        cc = GetComponent<CharacterController>();
        csa = GetComponent<ContestantStatApply>();
    }

    void Update()
    {
        if (player)
        {
            UpdatePlayer();
        }

        speed = csa.c.speed;
        jumpForce = csa.c.jumpStrength;
        gravity = csa.c.gravity;

        grounded = cc.isGrounded;
    }

    void UpdatePlayer()
    {
        Movement();
    }

    void Movement()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * vInput + transform.right * hInput;

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumpVelocity = jumpForce / 5.5f;
        }

        if (!grounded)
        {
            jumpVelocity -= gravity * Time.deltaTime;
        }
        else if (jumpVelocity < 0)
        {
            jumpVelocity = -2f;
        }

        move.y = jumpVelocity;

        cc.Move(move * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = csa.c.speed * 1.5f;
        }
        else
        {
            speed = csa.c.speed;
        }

        spdTxt.text = Mathf.Round(speed).ToString();
    }

    ContestantStatApply csa;

    public bool player;

    public float speed;
    public float jumpForce;
    public float gravity;

    Vector3 moveDir;
    float jumpVelocity;

    public TMP_Text spdTxt;

    CharacterController cc;
    public LayerMask whatIsGround;
    bool grounded;
}
