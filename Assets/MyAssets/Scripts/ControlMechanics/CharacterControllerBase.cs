﻿using UnityEngine;
using UnityEngine.AI;

public abstract class CharacterControllerBase :MonoBehaviour, ICharacterController
{
    public NavMeshAgent navMeshAgent;
    public GameObject target;

    public CharacterStats stats;

    public Animator anim;

    public ZombieAITargetDetecment targetDetecment;

    public void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = stats.movementSpeed;
    }

    public void Update()
    {
        if (targetDetecment.transformToPoint != null)
        {
            navMeshAgent.SetDestination(targetDetecment.transformToPoint.position);
        }
    }
}