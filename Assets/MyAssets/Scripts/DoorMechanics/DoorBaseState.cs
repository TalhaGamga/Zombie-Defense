using UnityEngine;
/*
  Abstract on each method means we need to define their
  functionality in classes that derive from BallBaseState
 */
public enum DoorState
{
    solid,
    broken
}

public abstract class DoorBaseState
{
    public abstract void EnterState(DoorStateManager door);
    public abstract void UpdateState(DoorStateManager door);
    public abstract void OnCollisionEnter(DoorStateManager door);
}
