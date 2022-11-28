using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float range;
    public LayerMask scanLayer;
    public Transform radarPoint;

    public TargetDetecmentConst targetDetecment;
    void Start()
    {
        targetDetecment = new TargetDetecmentConst(range, scanLayer, radarPoint);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,range);
    }

    // Update is called once per frame
    void Update()
    {
        Collider target = targetDetecment.FindClosestCollider();

        if (target != null)
        {
            transform.LookAt(target.transform.position);
        }
    }
}
