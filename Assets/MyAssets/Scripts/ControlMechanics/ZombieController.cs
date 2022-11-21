using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class ZombieController : CharacterControllerBase
{
    NavMeshAgent navMeshAgent;
    public GameObject target;

    [SerializeField] private ZombieStats stats;

    public event Action<float> OnHpPctChanged = delegate { };

    [SerializeField] Animator anim;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = stats.movementSpeed;
        GetComponentInParent<ZombieSpawnManager>().OnSettingTarget += SetTarget;
    }

    void Update()
    {
        CatchTarget();
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;
    }

    void CatchTarget()
    {
        if (target == null)
        {
            return;
        }

        navMeshAgent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<BuildingStatBase>(out BuildingStatBase buildingStatBase))
        {
            anim.SetTrigger("Attack");

        }
        if (collision.gameObject.TryGetComponent<CharacterStats>(out CharacterStats characterStats))
        {
            anim.SetTrigger("Attack");
        }
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.TryGetComponent<DoorStateManager>(out DoorStateManager doorStateManager))
    //    {
    //        StopCoroutine(_IEAttackToDoor);
    //    }
    //}
    //void AttackToDoor(DoorStateManager targetDoor)
    //{
    //    if (targetDoor == null)
    //    {
    //        return;
    //    }
    //    targetDoor.Hit(stats.damage / 10);
    //}

    IEnumerator IEAttackToDoor(StatBase stats, float damage)
    {
        while (stats != null)
        {
            //Hit(stats, damage);
            yield return null;
        }
    }


    //public void Hit(StatBase stats, float damage)
    //{ 
    //    punchEvent.objectReferenceParameter = stats.gameObject;
    //    punchEvent.floatParameter = this.stats.damage;
    //    Debug.Log(punchEvent.floatParameter);
    //    Debug.Log(punchEvent);

    //    anim.SetTrigger("Attack");
    //}
}