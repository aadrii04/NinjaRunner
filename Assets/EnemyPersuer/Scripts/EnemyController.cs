using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;

    [Header("Moving Parameters Settings")]
    [SerializeField] float speed;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] string rotateTag = "EnemyRotateTag";
    [SerializeField] string jumpTag = "JumpTag";

    Animator animator;
    Vector3 dir;
    bool rotated;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void StartEnemyMovement()
    {
        dir = Vector3.forward;
    }

    private void Update()
    {
        MovingEnemy();
    }

    private void MovingEnemy()
    {
        float movingEnemy = speed * Time.deltaTime;

        transform.Translate(dir * movingEnemy);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(rotateTag)) { EnemyRotation(); }

        if (other.CompareTag(jumpTag)) { EnemyJump(); }

        if(other.CompareTag("Player")) { other.GetComponentInParent<HealthController>().TakeDamage(10); }
    }

    private void EnemyRotation()
    {
        if (!rotated) { transform.Rotate(Vector3.up, 90); rotated = true; }
        else { transform.Rotate(Vector3.up, -90); rotated = false; }
    }

    private void EnemyJump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        animator.SetTrigger("jump");
    }
}
