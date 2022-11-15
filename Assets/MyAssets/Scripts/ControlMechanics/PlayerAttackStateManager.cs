using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackStateManager : AttackStateManagerBase
{
    private void Start()
    {
        InitState(attackState);
    }

    void Update()
    {
        currentState.UpdateState(this);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (attackState)
            {
                case AttackState.Gun:
                    SwitchState(AttackState.Ax);
                    currentState.EnterState(this);
                    break;

                case AttackState.Ax:
                    SwitchState(AttackState.Gun);
                    currentState.EnterState(this);
                    break;
            }
        }
    }
}
