using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class ContestantScript : MonoBehaviour
{
    void Start()
    {
        cc = GetComponent<CharacterController>();
        csa = GetComponent<ContestantStatApply>();
        gc = FindObjectOfType<GameController>();
        agent = GetComponent<NavMeshAgent>();
        if (!csa.c.arms)
        {
            gc.AddPoints(GetComponent<ContestantScript>(), 10);
        }
        if (!player)
        {
            cc.enabled = false;
            agent.enabled = true;
        }
    }

    void Update()
    {
        if (player)
        {
            UpdatePlayer();
        }
        else
        {
            UpdateAI();
        }

        pointsText[2].text = $"{points} points";

        speed = csa.c.speed;
        jumpForce = csa.c.jumpStrength;
        gravity = csa.c.gravity;
    }

    void UpdatePlayer()
    {
        Movement();

        if (transform.position.y <= -200)
        {
            transform.position = new Vector3(0, 10, 0);
        }

        pointsText[0].text = $"{points} points";
        pointsText[1].text = $"{points} points";

        grounded = cc.isGrounded;
    }

    void UpdateAI()
    {
        agent.SetDestination(gc.player.transform.position);

        agent.speed = speed;
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

    public void Eliminate()
    {
        gameObject.SetActive(false);
    }

    ContestantStatApply csa;

    public bool player;

    public float speed;
    public float jumpForce;
    public float gravity;
    float jumpVelocity;

    public TMP_Text spdTxt;

    CharacterController cc;
    NavMeshAgent agent;
    public LayerMask whatIsGround;
    bool grounded;

    GameController gc;

    public int votes;

    public int points;
    public TMP_Text[] pointsText;
}
