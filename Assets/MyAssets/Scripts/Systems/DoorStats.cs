using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorStats : StatBase
{
    public Action<DoorState> SwitchStateOnHpFull;

    private void Start()
    {
        //currentHealth = maxHealth;
        ChangeToPct(currentHp, maxHp);
    }

    public override void Die()
    {
        Debug.Log("doorStats die ' ý");
        return;
    }

    public override void ChangeToPct(float currentHealth, float maxHealth)
    {
        base.ChangeToPct(currentHealth, maxHealth);

        if (currentHealth == maxHealth)
        {
            SwitchStateOnHpFull?.Invoke(DoorState.Solid);
        }
    }

}
