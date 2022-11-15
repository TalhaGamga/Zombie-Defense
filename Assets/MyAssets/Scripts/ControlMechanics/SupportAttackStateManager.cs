using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportAttackStateManager : AttackStateManagerBase
{
    private void Start()
    {
        InitState(attackState);
    }

    public void Update()
    {
        currentState.UpdateState(this);
    }
}
