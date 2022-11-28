using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SolidState : DoorBaseState
{
    public override void EnterState(DoorStateManager door)
    {
        door.doorObj.SetActive(true);
        door.gameObject.layer = LayerMask.NameToLayer("Building");
    }

    public override void FixDoor(DoorStateManager door)
    {
    }

    public override void Hit(DoorStateManager door, DoorStats stats, float hit, GameObject doorObj)
    {
    }

    public override void OnCollisionEnter(DoorStateManager door, Collision collision)
    {
    }

    public override void OnCollisionExit(DoorStateManager door, Collision collision)
    {
    }

    public override void UpdateState(DoorStateManager door)
    {
    }
}
