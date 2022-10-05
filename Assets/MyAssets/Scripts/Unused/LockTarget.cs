using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTarget : MonoBehaviour
{

    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerMask;

    Collider closestCollider;
    void Start()
    {
        
    }

    public Collider[] colliders;
    Collider tempCollider;
    Vector3 sum = Vector3.zero;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Update()
    {
        DetectTarget();
    }

    void FixedUpdate()
    {
        colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
    }

    void DetectTarget()
    {
        if (FindClosestCollider() != null)
        {
            transform.LookAt(FindClosestCollider());
            Debug.DrawLine(FindClosestCollider(), transform.position, Color.red, 0f, true);
        }
    }

    Vector3 FindClosestCollider()
    {

        if (colliders.Length > 0)
        {
            tempCollider = colliders[0];
        }

        foreach (Collider collider in colliders)
        {
            if (collider != null)
            {
                sum += collider.transform.position;
            }
        }

        sum /= colliders.Length;
        Debug.Log(sum);
        return sum;
    }
}
