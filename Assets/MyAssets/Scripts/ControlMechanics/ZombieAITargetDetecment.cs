using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAITargetDetecment : MonoBehaviour
{
    [SerializeField] LayerMask farmingLayer;
    [SerializeField] LayerMask attacklayer;

    [SerializeField] float farmingSensorRange;
    [SerializeField] float attackSensorRange;

    [SerializeField] Transform radarPoint;
        
    public Collider[] farmingColliders;
    public Collider[] attackColliders;

    Collider tempCollider;

    Collider[] scanColliders;

    public Transform transformToPoint;

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
        farmingColliders = Physics.OverlapSphere(radarPoint.position, farmingSensorRange, farmingLayer);
    }

    public void AttackScan()
    {
        attackColliders = Physics.OverlapSphere(radarPoint.position, attackSensorRange, attacklayer);
    }


    public Transform FindColliderToPoint()
    {
        if (attackColliders.Length == 0)
        {
            scanColliders = farmingColliders;
        }

        else
        {
            scanColliders = attackColliders;
        }


        if (scanColliders.Length > 0)
        {
            tempCollider = scanColliders[0];

            foreach (Collider collider in scanColliders)
            {
                if (collider != null && tempCollider != null)
                {
                    if (Vector3.Distance(collider.transform.position, radarPoint.position) <
                        Vector3.Distance(tempCollider.transform.position, radarPoint.position))
                    {
                        tempCollider = collider;
                    }
                }


            }
            return tempCollider.transform;
        }

        return PlayerManager.Instance.player.transform;
      
    }
}

