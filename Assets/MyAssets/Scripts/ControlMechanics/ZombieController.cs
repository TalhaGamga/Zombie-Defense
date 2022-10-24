using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class ZombieController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public GameObject target;

    private Animator anim;

    Coroutine _IEAttackToDoor;

    [SerializeField] private ZombieStats stats;

    public event Action<float> OnHpPctChanged = delegate { };

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = stats.movementSpeed.GetValue();
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<DoorStateManager>(out DoorStateManager doorStateManager))
        {
            _IEAttackToDoor = StartCoroutine(IEAttackToDoor(doorStateManager));
        }

        if (collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.TakeDamage(stats.damage.GetValue());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<DoorStateManager>(out DoorStateManager doorStateManager))
        {
            StopCoroutine(_IEAttackToDoor);
        }
    }
    void AttackToDoor(DoorStateManager targetDoor) //ERROR IS HEREEEEE! ! ! !
    {
        if (targetDoor == null)
        {
            return;
        }
        targetDoor.Hit(stats.damage.GetValue() / 10);
    }
    IEnumerator IEAttackToDoor(DoorStateManager doorStateManager)
    { 
        while (doorStateManager != null)
        {
            AttackToDoor(doorStateManager);
            yield return new WaitForSeconds(stats.reattackSpeed.GetValue());
        }
    }
}