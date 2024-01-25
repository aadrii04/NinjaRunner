using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Grappler : MonoBehaviour
{
    [SerializeField] GameObject grapplerObject;
    [SerializeField] Transform player;
    [SerializeField] float impulseForce = 5f;
    [SerializeField] float grapplerCooldownTimer = 5f;
    [SerializeField] Transform grappleStartPoint;
    [SerializeField] TMP_Text cooldownText;
    [SerializeField] GameObject cooldownTextObject;

    bool grapplerAvailable;
    float initialGrapplerCooldownTimer;

    private void Start() { 
        SetGrapplerNotAvailable(); 
        initialGrapplerCooldownTimer = grapplerCooldownTimer; 
        cooldownTextObject.SetActive(false); }

    private void Update() { GrapplerCooldownTimer(); }

    public void UseGrappler()
    {
        if (grapplerAvailable && grapplerCooldownTimer <= 0)
        {
            GameObject grapplerInstance = Instantiate(grapplerObject, grappleStartPoint.position, grappleStartPoint.rotation);

            Vector3 forwardDirection = player.forward.normalized;
            Vector3 diagonalDirection = (forwardDirection + Vector3.up).normalized;

            Rigidbody playerRigidbody = player.GetComponent<Rigidbody>();
            playerRigidbody.AddForce(diagonalDirection * impulseForce, ForceMode.Impulse);
            cooldownTextObject.SetActive(true);
            GetComponent<PlayerController>().canJump = true;
            ResetCooldownTimer();
            Destroy(grapplerInstance, 1f);
        }
    }

    private void ResetCooldownTimer() { grapplerCooldownTimer = initialGrapplerCooldownTimer; }
    private void GrapplerCooldownTimer() {
        if (grapplerCooldownTimer > 0) { grapplerCooldownTimer -= Time.deltaTime;
            cooldownText.text = $"{(int)grapplerCooldownTimer}"; } }       

    public void SetGrapplerAvailable() { grapplerAvailable = true; }
    public void SetGrapplerNotAvailable() { grapplerAvailable = false; }
}