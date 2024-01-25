using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int damageAmount = 10;
    public GameObject player;
    HealthController playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //InflictDamageToPlayer();
        }
    }

    public void InflictDamageToPlayer(int damage)
    {
        playerHealth = GetComponent<HealthController>();
        playerHealth.TakeDamage(damage);
    }
}
