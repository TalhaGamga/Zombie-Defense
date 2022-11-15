using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class LockTargetBase : MonoBehaviour, IlockTarget
{




    //public Collider Detect(TargetDetecmentConst targetDetecment)
    //{


    //    targetDetecment.Scan();
    //    targetDetecment.FindClosestCollider(closestCollider);

    //    if (closestCollider != null)
    //    {
    //        Debug.Log(closestCollider);
    //        return closestCollider;
    //    }

    //    return null;
    //}
    public Collider Detect(TargetDetecmentConst targetDetecment)
    {
        Collider collider = targetDetecment.Detect();
        return collider;
    }
}
