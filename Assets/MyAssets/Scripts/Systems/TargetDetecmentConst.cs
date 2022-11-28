using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TargetDetecmentConst : MonoBehaviour
{
    public float range;
    public LayerMask scanLayer;
    public Transform radarPoint;

    public Collider[] colliders;

    Collider tempCollider;
    Collider closestCollider;
    public TargetDetecmentConst(float range, LayerMask layerMask, Transform radarPoint)
    {
        this.range = range;
        this.scanLayer = layerMask;
        this.radarPoint = radarPoint;
    }

    public void Scan()
    {
        colliders= Physics.OverlapSphere(radarPoint.position, range, scanLayer);

    }

    public Collider FindClosestCollider()
    {
        Scan();
        if (colliders.Length > 0)
        {
            tempCollider = colliders[0];

            foreach (Collider collider in colliders)
            {
                if (collider != null)
                {
                    if (Vector3.Distance(collider.transform.position, radarPoint.position) <
                        Vector3.Distance(tempCollider.transform.position, radarPoint.position))
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
