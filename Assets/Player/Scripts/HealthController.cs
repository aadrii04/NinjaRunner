using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] int maxHealth = 1;
    [SerializeField] float waitUntilDie = 2f;
    public int currentHealth;

    public UnityEvent OnDie;

    float maxRandom = 100f;
    float minRandom = 0f;

    Animator animator;

    private void Start() 
    { 
        RestartHealth();
        animator = GetComponentInChildren<Animator>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) { Die(); }
    }

    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;

        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
    }

    public void Die() 
    {
        float randomResult = Random.Range(minRandom, maxRandom);

        if(randomResult <= 50f) { animator.SetTrigger("deathFoward"); }
        else if(randomResult > 50f) { animator.SetTrigger("deathBackward"); }
        PlayerController.instance.DisableMechanics();
        WaitForDie();
    }

    public void WaitForDie()
    {
        StartCoroutine(WaitForDieCoroutine());
    }

    IEnumerator WaitForDieCoroutine()
    {
        yield return new WaitForSeconds(waitUntilDie);
        OnDie.Invoke();
    }

    private void RestartHealth() { currentHealth = maxHealth; }

}