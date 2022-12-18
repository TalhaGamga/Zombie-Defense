using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SupportAIController : CharacterControllerBase
{

    public GameObject ax;
    public AxCollision axCollision;

    public void Update()
    {
        if (targetDetecment.transformToPoint != null)
        {
            transform.LookAt(targetDetecment.transformToPoint);
            navMeshAgent.SetDestination(targetDetecment.transformToPoint.position);

            if (Vector3.Distance(transform.position,navMeshAgent.steeringTarget) < navMeshAgent.stoppingDistance)
            {
                anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
            }
            else
            {
                anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
            } 

            if (Vector3.Distance(transform.position, navMeshAgent.steeringTarget) < navMeshAgent.stoppingDistance && targetDetecment.transformToPoint != PlayerManager.Instance.player.transform)
            {
                anim.SetTrigger("AxAttack");
            }
        }
    }

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.TryGetComponent<BreakableStats>(out BreakableStats breakableStats))
    //    {
    //        anim.SetTrigger("AxAttack");
    //    }
    //    if (collision.gameObject.TryGetComponent<ZombieStats>(out ZombieStats zombieStats))
    //    {
    //        anim.SetTrigger("AxAttack");
    //    }
    //}
} 