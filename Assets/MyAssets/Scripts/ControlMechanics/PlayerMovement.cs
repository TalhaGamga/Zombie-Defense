using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private PlayerStats stats;

    public bool isMovable = true;

    Vector3 direction;
    [SerializeField] private Animator anim;

    [SerializeField] private TargetDetectment targetDetecment;
    [SerializeField] private NavMeshAgent navMesh;

    Quaternion rot;
    private void OnEnable()
    {
        EventManager.OnPlayingGame += Movable;
        EventManager.OnStoppingGame += DisMovable;
    }

    private void OnDisable()
    {
        EventManager.OnPlayingGame -= Movable;
        EventManager.OnStoppingGame -= DisMovable;
    }

    private void Start()
    {
    }
    private void Update()
    {
        Move();
    }

    void Move()
    {
        if (!isMovable) 
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
            {
                direction = (raycastHit.point - transform.position).normalized; 
                if (!targetDetecment.closestCollider)
                {
                    rot = Quaternion.LookRotation(direction, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, rot, 20 * Time.deltaTime);
                }
                navMesh.SetDestination(raycastHit.point);
            }
            Run();
        }

        else
        {
            navMesh.SetDestination(transform.position);
            Idle();
        }
    }
    private void Idle()
    { 
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

    void Movable()
    {
        isMovable = true;
    }

    void DisMovable()
    {
        isMovable = false;
        anim.SetFloat("Speed", 0, 0, 1);
    }
}
