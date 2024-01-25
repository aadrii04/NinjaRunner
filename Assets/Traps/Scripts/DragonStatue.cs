using UnityEngine;

public class DragonStatue : MonoBehaviour
{
    [SerializeField] int damage = 10;
    bool alreadyDamaged;

    private void Awake()
    {
        alreadyDamaged = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !alreadyDamaged)
        {
            alreadyDamaged = true;
            other.GetComponentInParent<PlayerController>().DisableMechanics();
            other.GetComponentInParent<HealthController>().TakeDamage(damage);            
        }
    }
}
