using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportLockTarget : LockTargetBase
{
    public LayerMask scanLayer;
    public Transform radarPoint;
    public float range;

    private void OnDrawGizmos()
    {    
    }
    private void Awake()
    {
    }

    private void Update()
    {
    }
}
