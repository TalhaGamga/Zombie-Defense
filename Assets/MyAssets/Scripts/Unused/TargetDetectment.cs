using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetDetectment : MonoBehaviour
{

    public float range;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform radarPoint;


    public Collider[] targetColliders;
    Collider tempCollider;
    Collider closestCollider;

    public Transform targetPos;

    private void Awake()
    {
        targetPos.position = Vector3.forward * 5 + transform.position.y * Vector3.up;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(radarPoint.transform.position, range);
    }

    void FixedUpdate()
    {
        targetColliders = Physics.OverlapSphere(radarPoint.transform.position, range, layerMask);
        Lock();
    }

    void Lock()
    {
        if (targetColliders.Length > 0)
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
        if (targetColliders.Length > 0)
        {
            tempCollider = targetColliders[0];
        }

        foreach (Collider collider in targetColliders)
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
