using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerTrap : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";
    [SerializeField] float impulseForce = 5f;
    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            animator.SetTrigger("bouncer");
            Vector3 backwardDirection = -other.transform.forward.normalized;
            Vector3 diagonalDirection = (backwardDirection + Vector3.up).normalized;

            other.GetComponentInParent<Rigidbody>().AddForce(diagonalDirection * impulseForce, ForceMode.Impulse);
        }
    }
}
