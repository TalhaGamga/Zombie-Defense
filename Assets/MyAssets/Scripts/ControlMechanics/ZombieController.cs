using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class ZombieController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public GameObject target; // make here gameObject and make it dynamic.

    private Animator anim;

    Coroutine _IEAttackToDoor;

    int hp = 5;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        GetComponentInParent<ZombieSpawnManager>().OnSettingTarget += SetTarget;
    }

    public void SetTarget(GameObject _target)
    {
        target = _target;
    }
    void Start()
    {
        /*anim = GetComponent<Animator>()*/
        //target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        CatchTarget();
    }

    void CatchTarget()
    {
        if (target == null)
        {
            return;
        }

        navMeshAgent.SetDestination(target.transform.position);


        //if (Vector3.Distance(target.position, transform.position) > navMeshAgent.stoppingDistance)
        //{
        //    Run();
        //}

        //else
        //{
        //    Idle();
        //}

    }



    //private void Idle()
    //{
    //    anim.SetFloat("Speed", 0, 0.2f, Time.deltaTime); 
    //}

    //private void Run()
    //{
    //    anim.SetFloat("Speed", 1f, 0.2f, Time.deltaTime);
    //}

    //private void OnCollisionStay(Collision collision) //ERROR IS HEREEEE! ! ! !
    //{
    //    //if (collision.gameObject.TryGetComponent<DoorController>(out DoorController doorController))
    //    //{
    //    //    if (doorController == null)
    //    //    {
    //    //        return;
    //    //    }

    //    //    if (timer > 3)
    //    //    {
    //    //        AttackToDoor(doorController);//error
    //    //        timer = 0;
    //    //    }
    //    //    //Debug.Log(timer);

    //    //    timer += Time.deltaTime;
    //    //}
    //}

    void AttackToDoor(DoorController targetDoor) //ERROR IS HEREEEEE! ! ! !
    {
        if (targetDoor == null)
        {
            return;
        }
        targetDoor.Hit(1);//error
    }
    IEnumerator IEAttackToDoor(DoorController doorController)
    {
        while (doorController != null)
        {
            AttackToDoor(doorController);
            yield return new WaitForSeconds(3f);
        }
    }


    public void Hit(int damage)
    {
        hp -= damage;
        if (hp < 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<DoorController>(out DoorController doorController))
        {

            _IEAttackToDoor = StartCoroutine(IEAttackToDoor(doorController));

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<DoorController>(out DoorController doorController))
        {
            StopCoroutine(_IEAttackToDoor);
        }
    }


}
