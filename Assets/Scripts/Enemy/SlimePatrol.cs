using UnityEngine;

public class SlimePatrol : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private Transform enemy; //delete this

    [Header("Movement parameters")]
    [SerializeField] private float speed;

    private Vector3 initScale;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private Transform player;

    private void Awake()
    {
        initScale = enemy.localScale;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(Vector2.Distance(enemy.position, player.position) < 1.5f)
        {
            anim.SetBool("moving", false);
            return;
        }
        else
        {
            anim.SetBool("moving", true);
        }

        MoveTowardsPlayer();
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
