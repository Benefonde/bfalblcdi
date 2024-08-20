using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using TMPro;

public class ContestantScript : MonoBehaviour
{
    void Awake()
    {
        if (player)
        {
            controls = new PlayerIngame();
            controls.Gameplay.Enable();
        }
    }

    void Start()
    {
        cc = GetComponent<CharacterController>();
        csa = GetComponent<ContestantStatApply>();
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
        else
        {
            speed = csa.c.speed;
            SetControls();
        }
    }

    void SetControls()
    {
        controls.Gameplay.Jump.performed += ctx => Jump();

        controls.Gameplay.Move.performed += ctx => moove = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => moove = Vector2.zero;

        controls.Gameplay.Rotate.performed += ctx => rootate = ctx.ReadValue<Vector2>();
        controls.Gameplay.Rotate.canceled += ctx => rootate = Vector2.zero;

        controls.Gameplay.Run.performed += ctx => speed = csa.c.speed * 1.5f;
        controls.Gameplay.Run.canceled += ctx => speed = csa.c.speed;

        controls.Gameplay.PerspectiveChange.performed += ctx => cam.SwitchPerspective();
        controls.Gameplay.UseArm.performed += ctx => cam.LMB();

        controls.Gameplay.Pause.performed += ctx => gc.Pause();
        controls.Gameplay.SpawnAngry.performed += ctx => gc.SpawnAngry();
    }

    void Jump()
    {
        if (grounded)
        {
            jumpVelocity = jumpForce / 5.5f;
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
        Vector2 m = new Vector2(moove.y, moove.x) * 50 * Time.deltaTime;

        Vector3 move = transform.forward * m.x + transform.right * m.y;

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

    public GameController gc;

    public int votes;

    public int points;
    public TMP_Text[] pointsText;

    public CamScript cam;

    public PlayerIngame controls;

    Vector2 moove;
    public Vector2 rootate;
}
