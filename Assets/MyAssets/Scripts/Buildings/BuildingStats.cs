using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStats : BuildingStatBase
{
    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("Building");
    }
}
