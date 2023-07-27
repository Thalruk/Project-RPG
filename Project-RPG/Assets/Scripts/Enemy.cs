using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float detectionRadius;
    [SerializeField] private float chaseRadius;
    [SerializeField] private float attackRadius;

    [SerializeField] private GameObject player;
    Vector3 directionToPlayer;
    float distance;

    NavMeshAgent agent;
    [SerializeField] Animator anim;
    [SerializeField] private SphereCollider sphereCollider;

    [Header("Equipment")]
    public Weapon weapon;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        sphereCollider.radius = detectionRadius;
        agent.updateRotation = false;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (player != null)
        {
            RotateTowardsPlayer();
            directionToPlayer = (player.transform.position - transform.position);
            distance = directionToPlayer.magnitude;

            if (distance <= chaseRadius && distance > attackRadius)
            {
                agent.isStopped = false;
                agent.destination = player.transform.position - directionToPlayer.normalized * 0.9f * attackRadius;
                anim.SetFloat("Speed", 1);
            }
            else if (distance <= attackRadius)
            {
                agent.isStopped = true;
                anim.SetFloat("Speed", 0);
                anim.SetTrigger("AttackOneHand");
            }
        }
        else
        {
            agent.isStopped = true;
            anim.SetFloat("Speed", 0);
        }
    }

    private void HandleAnimation()
    {
        if (distance <= chaseRadius && distance > attackRadius)
        {
            if (agent.isStopped)
            {
                anim.SetFloat("Speed", 0);
            }
            else
            {
                anim.SetFloat("Speed", 1);
            }
        }

        if (player != null)
        {
            if (distance <= attackRadius)
            {
                anim.SetFloat("Speed", 0);
                anim.SetTrigger("AttackOneHand");
            }
        }
    }

    private void RotateTowardsPlayer()
    {
        gameObject.transform.LookAt(new Vector3(player.transform.position.x, 0f, player.transform.position.z));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            player = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
