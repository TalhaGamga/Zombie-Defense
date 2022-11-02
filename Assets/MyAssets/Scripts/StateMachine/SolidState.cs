using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SolidState : DoorBaseState
{
    public override void EnterState(DoorStateManager door)
    {
        door.doorObj.SetActive(true);
        door.doorProps.CurrentHp = door.doorProps.MaxHp;
    }

    public override void FixDoor(DoorStateManager door)
    {
    }

    public override void Hit(DoorStateManager door, DoorProperties doorProps, float hit, GameObject doorObj)
    {
        doorProps.CurrentHp -= hit;

        if (door.doorProps.CurrentHp <= 0)
        {
            door.doorObj.SetActive(false);
            door.SwitchState(DoorState.Broken);
        }
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
