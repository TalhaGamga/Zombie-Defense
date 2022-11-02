using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetDetectment : MonoBehaviour
{

    public float attackRange;
    public float breakableRange = 4f;

    [SerializeField] private LayerMask attackLayerMask;
    [SerializeField] private LayerMask breakableLayerMask;
    [SerializeField] private Transform radarPoint;


    public Collider[] zombieColliders;
    public Collider[] breakableColliders;

    Collider tempCollider;
    Collider closestCollider;

    public Transform targetPos;

    private void Awake()
    {
        targetPos.position = Vector3.forward * 5 + transform.position.y * Vector3.up;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(radarPoint.transform.position, attackRange);

        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(radarPoint.transform.position, breakableRange);
    }

    void FixedUpdate()
    {
        zombieColliders = Physics.OverlapSphere(radarPoint.transform.position, attackRange, attackLayerMask);
        breakableColliders = Physics.OverlapSphere(radarPoint.transform.position, breakableRange, breakableLayerMask);
        Lock();
    }

    void Lock()
    {
        if (zombieColliders.Length > 0)
        {
            targetPos.position = FindClosestCollider().transform.position;
            Vector3 direction = (targetPos.position - transform.position).normalized;

            var rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 1440 * Time.deltaTime);

            Debug.DrawLine(FindClosestCollider().transform.position, transform.position, Color.red, 0f, true);
        }

        else
        {
            targetPos.transform.localPosition = new Vector3(0, 0.4f, 1);
        }
    }

    Collider FindClosestCollider()
    {
        if (zombieColliders.Length > 0)
        {
            tempCollider = zombieColliders[0];
        }

        foreach (Collider collider in zombieColliders)
        {
            if (collider != null)
            {
                if (Vector3.Distance(collider.transform.position, transform.position) < Vector3.Distance(tempCollider.transform.position, transform.position))
                {
                    tempCollider = collider;
                }
            }
        }

        closestCollider = tempCollider;
        return closestCollider;
    }
}