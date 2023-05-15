using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    // References
    private Animator anim;
    private PlayerHealth playerHealth;

    private SlimePatrol slimePatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        slimePatrol = GetComponentInParent<SlimePatrol>();
    }

    // Update is called once per frame
    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if (PlayerInSight())
        {
                //Debug.Log("Cooldown timer: " + cooldownTimer);
                //Debug.Log("Attack cooldown: " + attackCooldown);
            slimePatrol.enabled = false; // Stop moving when in sight
            if (cooldownTimer >= attackCooldown)
            {
            //Debug.Log("Preparing to attack!");
                Attack();
            }
        }
        else if(slimePatrol != null)
        {
            slimePatrol.enabled = true; // Resume moving when not in sight

        }
    }

   private bool PlayerInSight()
   {
       Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

       RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + (Vector3)direction * range * transform.localScale.x,
           new Vector3(boxCollider.bounds.size.x * colliderDistance, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
           0, direction, 0, playerLayer);

       if (hit.collider != null)
       {
           playerHealth = hit.collider.GetComponent<PlayerHealth>();
           Debug.Log("Player spotted!");
       }
       else
       {
           Debug.Log("Player not in sight!");
       }

       return hit.collider != null;
    
   }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x,
            new Vector3(boxCollider.bounds.size.x * colliderDistance, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void Attack()
    {
        Debug.Log("Attacking!!!!!!!");
        anim.SetTrigger("meleeAttack");
        cooldownTimer = 0;

    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
