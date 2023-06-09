using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Animator animator;
    private int currentHealth;

    public UnityEvent OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (animator != null)
    {
        animator.SetTrigger("hurt");
    }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (animator != null)
        {
            animator.SetBool("die", true);
            OnDeath.Invoke();
            Destroy(gameObject, 0.7f); // delay of 1 second
            EnemyBehavior slime = this.GetComponent<EnemyBehavior>();
            slime.speed = 0;
        }
    }

    public int SendCurrentHealth()
    {
        return currentHealth;
    }
}
