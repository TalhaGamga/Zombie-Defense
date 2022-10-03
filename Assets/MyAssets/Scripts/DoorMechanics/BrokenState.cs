using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenState : DoorBaseState
{
    public override void EnterState(DoorStateManager door)
    {
        throw new System.NotImplementedException();
    }

    public override void OnCollisionEnter(DoorStateManager door)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(DoorStateManager door)
    {
        throw new System.NotImplementedException();
    }
}
