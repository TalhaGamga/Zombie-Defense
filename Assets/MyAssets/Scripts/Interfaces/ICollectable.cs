using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    public void Collect();

    public void PushToDoor(Transform target, DoorStateManager door);
}