using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OldContestantScript : MonoBehaviour
{
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        csa = GetComponent<ContestantStatApply>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (player)
        {
            UpdatePlayer();
        }

        speed = csa.c.speed;
        jumpForce = csa.c.jumpStrength;

        grounded = Physics.Raycast(transform.position, Vector3.down, 0.2f, whatIsGround);

        if (grounded)
        {
            rb.drag = 7.5f;
        }
        else
        {
            rb.drag = 5;
        }
    }

    void UpdatePlayer()
    {

    }

    void FixedUpdate()
    {
        if (player)
        {
            Movement();
        }
    }

    void Movement()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        float spd = speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            spd = speed * 1.5f;
        }
        else
        {
            spd = speed;
        }

        spdTxt.text = Mathf.Round(spd).ToString();

        moveDir = transform.forward * vInput + transform.right * hInput;

        rb.AddForce(moveDir.normalized * spd * 7.5f, ForceMode.Force);

        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce * 1.35f, ForceMode.Impulse);
    }

    ContestantStatApply csa;

    public bool player;

    public float speed;
    public float jumpForce;

    Vector3 moveDir;

    public TMP_Text spdTxt;

    Rigidbody rb;
    CharacterController cc;
    public LayerMask whatIsGround;
    bool grounded;
}
