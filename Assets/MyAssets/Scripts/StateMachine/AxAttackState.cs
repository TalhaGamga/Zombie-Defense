using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxAttackState : CharacterAttackBaseState
{
    public override void EnterState(AttackStateManager attack)
    {
        Debug.Log(attack.attackState);
        attack.gunHolderRig.weight = 0;
        attack.axHolderRig.weight = 1;

        attack.gun.SetActive(false);
        attack.ax.SetActive(true);

        attack.axCollision.gameObject.SetActive(false);
        attack.GetProps(attack.attackState);
        attack.axCollision.damage = attack.props.damage;
        attack.SetTargetDetecment();
    }

    public override void Attack(AttackStateManager attack)
    {
        attack.playerAnim.SetTrigger("AxAttack");
    }

    public override void UpdateState(AttackStateManager attack)
    {
        if (attack.TargetDetectment.zombieColliders.Length > 0)
        {
            Attack(attack);
        }
    }

    public override void OnCollisionEnter(AttackStateManager attack, Collision collision)
    {
    }
}
