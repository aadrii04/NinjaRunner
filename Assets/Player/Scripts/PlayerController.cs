using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [Header("Moving Parameters Settings")]
    [SerializeField] float speed;
    public float jumpForce = 7f;
    [SerializeField] float dashForce = 5f;
    [SerializeField] InputActionReference playerMovement;
    [SerializeField] InputActionReference playerDash;
    [SerializeField] InputActionReference playerGrappler;
    [SerializeField] float dashCooldownTimer = 1f;
  
    [HideInInspector] public bool canJump = true;
    bool clicked = false;
    float initialDashCooldownTimer;
    bool mechanics;
    float defaultSpeed;

    Vector3 dir;
    Vector3 stopDir;

    [Header("Player Colliders")]
    [SerializeField] GameObject bodyCollider;

    [Header("Ground Tag Names")]
    [SerializeField] string groundTag = "Ground";
    [SerializeField] string rotateTag = "RotateTag";
    [SerializeField] string jumpTag = "JumpTag";

    [Header("Player Animations")]
    Animator animator;

    Rigidbody rb;

    public enum PlayerStates 
    {   Jump,
        Rotate,
        Crashed
    }

    public PlayerStates playerStates = PlayerStates.Jump;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        playerMovement.action.Enable();
        playerDash.action.Enable();
        playerGrappler.action.Enable();
    }
    private void OnDisable()
    {
        playerMovement.action.Disable();
        playerDash.action.Disable();
        playerGrappler.action.Disable();
    }

    private void Start()
    {
        //dir = Vector3.forward;
        stopDir = new Vector3(0, 0, 0);
        initialDashCooldownTimer = dashCooldownTimer;
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    public void StartPlayerMovement()
    {
        dir = Vector3.forward;
        mechanics = true;
        defaultSpeed = speed;
    }

    void Update()
    {
        if (mechanics)
        {
            MovingPlayer();
            DashCooldownTimer();

            if (playerStates == PlayerStates.Rotate && playerMovement.action.triggered) { Rotate(); }

            if (playerStates == PlayerStates.Jump && canJump && playerMovement.action.triggered) { Jump(); }

            if (dashCooldownTimer <= 0 && playerDash.action.triggered) { Dash(); dashCooldownTimer = initialDashCooldownTimer; }

            if (playerGrappler.action.triggered) { GetComponent<Grappler>().UseGrappler(); canJump = false; }

            if(playerStates == PlayerStates.Crashed) { Crashed(); }
        }
    }

    private void DashCooldownTimer() { if (dashCooldownTimer > 0) { dashCooldownTimer -= Time.deltaTime; } }

    private void MovingPlayer()
    {
        float movingPlayer = speed * Time.deltaTime;

        transform.Translate(dir * movingPlayer);
    }

    private void Rotate()
    {
        if (!clicked) { transform.Rotate(Vector3.up, 90); clicked = true; }
        else { transform.Rotate(Vector3.up, -90); clicked = false; }
    }

    void Jump()
    {
        animator.SetTrigger("jump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        canJump = false;
    }

    void Dash()
    {
        if (!clicked) { rb.AddForce(Vector3.forward * dashForce, ForceMode.VelocityChange); }
        else { rb.AddForce(Vector3.right * dashForce, ForceMode.VelocityChange); }

        animator.SetTrigger("dash");
        StartCoroutine(EndDash());
    }

    IEnumerator EndDash()
    {
        yield return new WaitForSeconds(0.5f);
    }

    private void Crashed()
    {
        animator.SetTrigger("crash");
        GetComponent<HealthController>().WaitForDie();
        DisableMechanics();
    }

    public void EnableMechanics()
    {
        mechanics = true;
        speed = defaultSpeed;
    }
    public void DisableMechanics()
    {
        speed = 0;
        dir = stopDir;
        mechanics = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(groundTag) || other.gameObject.CompareTag(jumpTag)) { playerStates = PlayerStates.Jump; canJump = true; }

        if (other.gameObject.CompareTag(rotateTag)) { playerStates = PlayerStates.Rotate; }

        if(other.gameObject.CompareTag(jumpTag) || other.gameObject.CompareTag(groundTag) || other.gameObject.CompareTag(rotateTag)) { ScoreManager.instance.IncreaseScore(1); }
    }
}