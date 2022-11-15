using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AxAttackState : CharacterAttackBaseState
{
    public override void EnterState(AttackStateManagerBase attack)
    {
        attack.gunHolderRig.weight = 0;
        attack.axHolderRig.weight = 1;

        attack.gun.SetActive(false);
        attack.ax.SetActive(true);

        attack.axCollision.gameObject.SetActive(false);
        attack.GetProps(attack.attackState);
        attack.axCollision.damage = attack.props.damage;
        attack.SetTargetDetecment();

        PlayerManager.Instance.stats.speedMultier = 1;
    }

    public override void Attack(AttackStateManagerBase attack)
    {
        attack.playerAnim.SetTrigger("AxAttack");
    }

    public override void UpdateState(AttackStateManagerBase attack)
    {
        if (attack.TargetDetectment.closestCollider)
        {
            Attack(attack);
        }
    }

    public override void OnCollisionEnter(AttackStateManagerBase attack, Collision collision)
    {
    }
}
