using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThought : MonoBehaviour
{
    public Transform player; //The player's transform

    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRange;
    [SerializeField] private int damage;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

     // References
    private Animator anim;
    private PlayerHealth playerHealth;

    public float speed = 3f; // The speed at which the enemy moves towards the player

    private void Update()
    {
        if (player != null) // Check if the player is still alive and in the scene
        {
            
            float distanceToTarget = Vector2.Distance(transform.position, player.position);

            if (distanceToTarget <= attackRange)
            {
                Debug.Log("Attacking player!");
                Attack();
            }
            else
            {
                // gå mod spiller
                MoveTowardsPlayer();
            }
        }
    }


    private void Attack()
    {
        Debug.Log("Attacking!!!!!!!");
        anim.SetTrigger("meleeAttack");
        cooldownTimer = 0;

    }

    private void DamagePlayer()
    {
            playerHealth.TakeDamage(damage);
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - enemy.position).normalized;
        float step = speed * Time.deltaTime;
        enemy.position = Vector3.MoveTowards(enemy.position, player.position, step);

        // Make enemy face the direction it is moving based on the x-axis
        int directionFacing = direction.x > 0 ? 1 : -1;
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * directionFacing, initScale.y, initScale.z);

        anim.SetBool("moving", true);
    }
}

