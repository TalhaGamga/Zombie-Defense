using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetDetectment : MonoBehaviour
{
    public float range;

    [SerializeField] private LayerMask attackLayerMask;
    [SerializeField] private LayerMask breakableLayerMask;
    [SerializeField] private Transform radarPoint;

    public Collider[] zombieColliders;
    public Collider[] breakableColliders;

    Collider tempCollider;
    public Collider closestCollider;

    public Transform crossPos;

    public delegate void LockDel();
    public LockDel LockFunc;

    private void Awake()
    {
        crossPos.position = Vector3.forward * 5 + transform.position.y * Vector3.up;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(radarPoint.transform.position, range);
    }

    void FixedUpdate()
    {
        LockFunc();
    }


    void GunLock()
    {
        GunScan();
         
        GunFindClosestCollider();
        if (!closestCollider)
        {
            crossPos.transform.localPosition = Vector3.Lerp(crossPos.transform.localPosition, new Vector3(0, 0.2f, 1),0.5f);
            return;
        }

        crossPos.position = closestCollider.transform.position;
        Vector3 direction = (crossPos.position - transform.position).normalized;

        transform.forward = new Vector3(direction.x, 0, direction.z) * Time.deltaTime;
    }

    void GunFindClosestCollider()
    {
        if (zombieColliders.Length < 1)
        {
            closestCollider = null;
            return;
        }

        tempCollider = zombieColliders[0];

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
    }

    void GunScan()
    {
        zombieColliders = Physics.OverlapSphere(radarPoint.transform.position, range, attackLayerMask);
    }

    void AxLock()
    {
        AxScan();

        Collider axScannedCollider = AxFindClosestCollider();

        if (axScannedCollider != null)
        {
            Vector3 direction = (axScannedCollider.transform.position - transform.position).normalized;
            var rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 1440 * Time.deltaTime);
        }

    }

    Collider AxFindClosestCollider()
    {
        if (zombieColliders.Length > 0)
        {
            tempCollider = zombieColliders[0];

            foreach (Collider collider in zombieColliders)
            {
                if (collider != null)
                {
                    if (Vector3.Distance(collider.transform.position, transform.position) <
                        Vector3.Distance(tempCollider.transform.position, transform.position))
                    {
                        tempCollider = collider;
                    }
                }
            }

            closestCollider = tempCollider;
        }

        else
        {
            if (breakableColliders.Length > 0)
            {
                tempCollider = breakableColliders[0];

                foreach (Collider collider in breakableColliders)
                {
                    if (collider != null)
                    {
                        if (Vector3.Distance(collider.transform.position, transform.position) <
                            Vector3.Distance(tempCollider.transform.position, transform.position))
                        {
                            tempCollider = collider;
                        }
                    }
                }

                closestCollider = tempCollider;
            }

            else
            {
                closestCollider = null;
            }
        }

        return closestCollider;
    }

    void AxScan()
    {
        breakableColliders = Physics.OverlapSphere(radarPoint.transform.position, range, breakableLayerMask);
        zombieColliders = Physics.OverlapSphere(radarPoint.transform.position, range, attackLayerMask);
    }

    public void InitLockFunc(AttackState state)
    {
        switch (state)
        {
            case AttackState.Gun:
                LockFunc = GunLock;
                break;

            case AttackState.Ax:
                LockFunc = AxLock;
                break;
        }
    }
}
