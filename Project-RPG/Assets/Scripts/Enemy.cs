using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : Creature
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

    [SerializeField] Slider healthSlider;
    [SerializeField] Image healthSliderFill;

    [SerializeField] Vector3 healtSliderOffset;

    [Header("Equipment")]
    public Weapon weapon;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        sphereCollider.radius = detectionRadius;
        agent.updateRotation = false;

        Health.CurrentValue = Health.maxValue.Value;

        healthSlider.maxValue = Health.maxValue.Value;
        healthSlider.value = Health.CurrentValue;
    }

    private void Update()
    {
        Move();
        healthSlider.transform.rotation = Camera.main.transform.rotation;
        healthSlider.transform.position = transform.position + healtSliderOffset;
    }

    private void Move()
    {
        if(Health.CurrentValue > 0)
        {
            if (player != null)
            {
                //RotateTowardsPlayer();
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
        else
        {
            agent.isStopped = true;
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

    private void UpdateHealthSlider()
    {
        healthSlider.value = Health.CurrentValue;
        healthSliderFill.color = Color.Lerp(Color.red, Color.black, (Health.maxValue.Value - Health.CurrentValue) / (float)Health.maxValue.Value);

    }
    public override void TakeDamage(int value)
    {
        base.TakeDamage(value);
        UpdateHealthSlider();
        if(Health.CurrentValue == 0)
        {
            anim.SetTrigger("Dead");
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
