using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    public void Collect(Transform parent);

    public void PushToDoor(Transform target, DoorStateManager door);
}