using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float detectionRadius;
    NavMeshAgent agent;
    SphereCollider sphereCollider;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = detectionRadius;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
