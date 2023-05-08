using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player; // The player's transform

    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown; // delete this
    [SerializeField] private float attackRange;
    [SerializeField] private int damage;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = 2f;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    // References
    private Animator anim;
    private PlayerHealth playerHealth;

    public float speed = 3f; // The speed at which the enemy moves towards the player

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (player != null) // Check if the player is still alive and in the scene
        {
            float distanceToTarget = Vector2.Distance(transform.position, player.position);


            Debug.Log("Distance to player: " + distanceToTarget);
            Debug.Log("Cooldown timer: " + cooldownTimer);
            
            if (distanceToTarget <= attackRange && cooldownTimer <= 0)
            {
                Debug.Log("Attacking player!");
                Attack();
            }
            else
            {
                // Move towards the player
                MoveTowardsPlayer();
            }

            cooldownTimer -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        anim.SetTrigger("meleeAttack");
        DamagePlayer();
        cooldownTimer = attackCooldown;
    }

    private void DamagePlayer()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);
        if (hitObjects.Length > 0)
        {
            PlayerHealth health = hitObjects[0].GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer > colliderDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);

            // Make enemy face the direction it is moving based on the x-axis
            int directionFacing = direction.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * directionFacing, transform.localScale.y, transform.localScale.z);

            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }
}
