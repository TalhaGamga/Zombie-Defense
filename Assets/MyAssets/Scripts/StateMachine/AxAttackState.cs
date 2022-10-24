using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxAttackState : CharacterAttackBaseState
{
    public override void Attack(AttackStateManager attack, WeaponProperties props)
    {
        attack.playerAnim.SetTrigger("AxAttack");
    }

    public override void EnterState(AttackStateManager attack)
    {
    }

    public override void UpdateState(AttackStateManager attack)
    {
    }
}
