using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorStats : BuildingStatBase
{
    public Action<DoorState> OnSwitchState;

    private void Start()
    {
        ChangeToPct(currentHp, maxHp);
    }

    public override void Die()
    {
        OnSwitchState(DoorState.Broken);
    }

    public override void ChangeToPct(float currentHealth, float maxHealth)
    {
        base.ChangeToPct(currentHealth, maxHealth);

        if (currentHealth == maxHealth)
        {
            OnSwitchState?.Invoke(DoorState.Solid);
        }
    }

}
