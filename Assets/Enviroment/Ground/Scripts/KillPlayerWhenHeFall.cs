using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerWhenHeFall : MonoBehaviour
{
    int damage = 10;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<HealthController>().TakeDamage(damage);
        }
    }
}
