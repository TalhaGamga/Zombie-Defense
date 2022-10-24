using UnityEngine;
/*
  Abstract on each method means we need to define their
  functionality in classes that derive from BallBaseState
 */
public abstract class DoorBaseState 
{
    public abstract void EnterState(DoorStateManager door);
    public abstract void UpdateState(DoorStateManager door);
    public abstract void Hit(DoorStateManager door, DoorProperties doorProp, float hit, GameObject doorObj);
    public abstract void FixDoor(DoorStateManager door);
    public abstract void OnCollisionEnter(DoorStateManager door, Collision collision);

    public abstract void OnCollisionExit(DoorStateManager door, Collision collision);
}
