using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


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
        }
    }
    public int SendCurrentHealth(){
        return currentHealth;
    }
}
