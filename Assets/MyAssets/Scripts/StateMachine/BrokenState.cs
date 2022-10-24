using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BrokenState : DoorBaseState
{
    public override void EnterState(DoorStateManager door)
    {
        door.timer = 0;
        door.zombieSpawnManager.OnSettingTarget(PlayerManager.Instance.player);
    }

    public override void FixDoor(DoorStateManager door)
    {
        //throw new System.NotImplementedException();
    }
    public override void Hit(DoorStateManager door, DoorProperties doorProp, float hit, GameObject doorObj)
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState(DoorStateManager door)
    {
        //throw new System.NotImplementedException();
    }
    public override void OnCollisionEnter(DoorStateManager door, Collision collision)
    {

        if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement movement))
        {
            door.CallIEOnBase();
        }
    }

    public override void OnCollisionExit(DoorStateManager door, Collision collision)
    {

        if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement movement))
        {
            door.CallIELeftOnBase();
        }
    }
}
