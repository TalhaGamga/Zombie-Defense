using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TargetDetecmentBase<TScanner> where TScanner : MonoBehaviour, ITargetDetecment
{
    private LayerMask scanLayerMask;
    private float scanRadius;
    private Transform scanPoint;

    public TargetDetecmentBase(LayerMask layerMask, float radius, Transform point)
    {
        scanLayerMask = layerMask;
        radius = scanRadius;
        scanPoint = point;
    }

    public Collider[] scannedColliders;

    Collider closestCollider;
    Collider tempCollider;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(scanPoint.transform.position, scanRadius);
    }

    void FixedUpdate()
    {
        scannedColliders = Physics.OverlapSphere(scanPoint.transform.position, scanRadius, scanLayerMask);
    }

    public Collider FindClosestCollider(TScanner scanner)
    {
        if (scannedColliders.Length > 0)
        {
            tempCollider = scannedColliders[0];
        }

        foreach (Collider collider in scannedColliders)
        {
            if (collider != null)
            {
                if (Vector3.Distance(collider.transform.position, scanner.transform.position) < Vector3.Distance(tempCollider.transform.position, scanner.transform.position))
                {
                    tempCollider = collider;
                }
            }
        }

        closestCollider = tempCollider;
        return closestCollider;
    }
}