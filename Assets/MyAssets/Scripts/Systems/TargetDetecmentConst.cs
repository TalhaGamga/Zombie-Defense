using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TargetDetecmentConst
{
    public float range;
    public LayerMask scanLayer;
    public Vector3 radarPoint;

    public Collider[] colliders;

    Collider tempCollider;
    Collider closestCollider;
    public TargetDetecmentConst(float range, LayerMask layerMask, Vector3 radarPoint)
    {
        this.range = range;
        this.scanLayer = layerMask;
        this.radarPoint = radarPoint;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(radarPoint, range);
    }

    public void Scan()
    {
        colliders = Physics.OverlapSphere(radarPoint, range, scanLayer);
    }

    public Collider FindClosestCollider()
    {
        if (colliders.Length > 0)
        {
            tempCollider = colliders[0];

            foreach (Collider collider in colliders)
            {
                if (collider != null)
                {
                    if (Vector3.Distance(collider.transform.position, radarPoint) <
                        Vector3.Distance(tempCollider.transform.position, radarPoint))
                    {
                        tempCollider = collider;
                    }
                }
            }
            closestCollider = tempCollider;
            return closestCollider;
        }

        return null;
    }

    public Collider Detect()
    {
        Scan();
        return FindClosestCollider();
    }
}
