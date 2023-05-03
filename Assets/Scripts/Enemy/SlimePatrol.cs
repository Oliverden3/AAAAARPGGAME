using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePatrol : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform patrolPointA;
    [SerializeField] private Transform patrolPointB;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;

    private Vector3 initScale;
    private Vector3 targetPosition;
    private Vector3 previousPosition;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;
    private bool isIdling;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
        targetPosition = patrolPointA.position;
        previousPosition = patrolPointB.position;
    }

    private void Update()
    {
        if (!isIdling)
        {
            MoveTowardsTarget();

            if (Vector3.Distance(enemy.position, targetPosition) <= 0.1f)
            {
                isIdling = true;
            }
        }
        else
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= idleDuration)
            {
                isIdling = false;
                idleTimer = 0;

                Transform temp = patrolPointA;
                patrolPointA = patrolPointB;
                patrolPointB = temp;
                targetPosition = patrolPointA.position;
                previousPosition = patrolPointB.position;
            }
        }

        anim.SetBool("moving", !isIdling);
    }

    private void MoveTowardsTarget()
    {
        float step = speed * Time.deltaTime;
        enemy.position = Vector3.MoveTowards(enemy.position, targetPosition, step);

        // Make enemy face the direction it is moving based on the x-axis
        int direction = targetPosition.x > previousPosition.x ? 1 : -1;
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
    }
}
