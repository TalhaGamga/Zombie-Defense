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
        throw new System.NotImplementedException();
    }

    public override void Hit(DoorStateManager door, DoorProperties doorProps, int hit, GameObject doorObj)
    {
        doorProps.CurrentHp -= hit;

        if (door.doorProps.CurrentHp < 1)
        {
            door.doorObj.SetActive(false);
            door.SwitchState(DoorState.broken);
            door.timer = 0;
            door.zombieSpawnManager.OnSettingTarget(PlayerManager.Instance.player);
        }
    }

    public override void OnCollisionEnter(DoorStateManager door, Collision collision)
    {
        //throw new System.NotImplementedException();
    }

    public override void OnCollisionExit(DoorStateManager door, Collision collision)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(DoorStateManager door)
    {
    }
}
