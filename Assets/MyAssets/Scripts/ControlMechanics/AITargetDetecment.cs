using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AITargetDetecment : MonoBehaviour
{
    [SerializeField] LayerMask farmingLayer;
    [SerializeField] LayerMask attacklayer;

    [SerializeField] float farmingSensorRange;
    [SerializeField] float attackSensorRange;

    [SerializeField] Transform radarPoint;

    public Collider[] farmingColliders;
    public Collider[] attackColliders;

    public int farmingCollLen;
    public int attackCollLen;

    Collider tempCollider;

    Collider[] scanColliders;

    int size;

    public Transform transformToPoint;

    private void Awake()
    {
        farmingColliders = new Collider[200];
        attackColliders = new Collider[200];
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(radarPoint.position, farmingSensorRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(radarPoint.position, attackSensorRange);
    }

    private void Update()
    {
        transformToPoint = FindColliderToPoint();
    }

    private void FixedUpdate()
    {
        FarmingScan();
        AttackScan();
    }

    public void FarmingScan()
    {
        farmingCollLen = Physics.OverlapSphereNonAlloc(radarPoint.position, farmingSensorRange, farmingColliders,farmingLayer);
    }

    public void AttackScan()
    {
        attackCollLen = Physics.OverlapSphereNonAlloc(radarPoint.position, attackSensorRange, attackColliders, attacklayer);
    }


    public Transform FindColliderToPoint()
    {
        if (attackCollLen == 0)
        {
            if (farmingCollLen>0)
            {
                scanColliders = farmingColliders;
                size = farmingCollLen;
            }
        }

        else
        {
            if (attackCollLen>0)
            {
                scanColliders = attackColliders;
                size = attackCollLen;
            }
        }

        if (size > 0)
        {
            tempCollider = scanColliders[0];

            for (int i = 1; i < size; i++)
            {
                if (tempCollider != null && scanColliders[i] != null)
                {
                    if (Vector3.Distance(scanColliders[i].transform.position, radarPoint.position) <
                        Vector3.Distance(tempCollider.transform.position, radarPoint.position))
                    {
                        tempCollider = scanColliders[i];
                    }
                }
            }


            if (tempCollider != null)
            {
                return tempCollider.transform;
            }
        }

        if (EventManager.GetPlayer?.Invoke().player)
        {
            return EventManager.GetPlayer?.Invoke().player.transform;
        }

        return null;
    }
}

