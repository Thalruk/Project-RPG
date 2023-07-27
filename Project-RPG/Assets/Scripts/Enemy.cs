using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float detectionRadius;
    [SerializeField] private float chaseRadius;
    [SerializeField] private float attackRadius;

    [SerializeField] private GameObject player;

    NavMeshAgent agent;
    [SerializeField] Animator anim;
    [SerializeField] private SphereCollider sphereCollider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        sphereCollider.radius = detectionRadius;
    }

    private void Update()
    {
        Move();
        //HandleAnimation();
    }

    private void Move()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position);
            float distane = direction.magnitude;

            if (distane <= chaseRadius && distane > attackRadius)
            {
                Debug.Log("moving to player");
                agent.isStopped = false;
                agent.destination = player.transform.position - direction.normalized * attackRadius;
            }
            else if (distane <= attackRadius)
            {
                Debug.Log("attacking player");

                agent.isStopped = true;
            }
        }

        Debug.Log(agent.isStopped);
    }

    private void HandleAnimation()
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
