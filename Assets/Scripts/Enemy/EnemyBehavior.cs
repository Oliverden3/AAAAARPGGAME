using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public float speed = 3f;

    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackRange;
    [SerializeField] private int damage;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    private float cooldownTimer;
    private Animator anim;
    private PlayerHealth playerHealth;
    private bool isPlayerInRange => Vector2.Distance(transform.position, player.position) <= attackRange;

    private void Start()
    {
        if (!player)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        playerHealth = player.GetComponent<PlayerHealth>();
        cooldownTimer = 0f;
    }

    private void Update()
    {
        if (!player) return;
        cooldownTimer += Time.deltaTime;
        HandleMovementAndAttacking();
    }

    private void HandleMovementAndAttacking()
    {
        if (isPlayerInRange && cooldownTimer >= attackCooldown)
        {
            Attack();
        }
        else
        {
            MoveTowardsPlayer();
        }
    }

    private void Attack()
    {
        anim.SetTrigger("meleeAttack");
        DamagePlayer();
        cooldownTimer = 0;
    }

    private void DamagePlayer()
    {
        Collider2D[] hitObjects = Physics2D.OverlapCircleAll(transform.position, attackRange, playerLayer);
        foreach (var hitObject in hitObjects)
        {
            PlayerHealth health = hitObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }

   private void MoveTowardsPlayer()
{
    float distanceToPlayer = Vector2.Distance(transform.position, player.position);

    // Stop moving when within attack range
    if (distanceToPlayer <= attackRange)
    {
        anim.SetBool("moving", false);
        return;
    }

    Vector3 direction = (player.position - transform.position).normalized;
    float step = speed * Time.deltaTime;
    transform.position = Vector3.MoveTowards(transform.position, player.position, step);
    int directionFacing = direction.x > 0 ? 1 : -1;
    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * directionFacing, transform.localScale.y, transform.localScale.z);
    anim.SetBool("moving", true);
}

}
