using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player; //The player's transform

    public float speed = 3f; // The speed at which the enemy moves towards the player
    public float attackRange = 2f; // The distance at which the enemy can attack the player

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
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
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
