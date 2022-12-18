using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AxAttackState : AttackBaseState
{
    public override void EnterState(AttackStateManager attack)
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

    public override void Attack(AttackStateManager attack)
    {
            attack.playerAnim.SetTrigger("AxAttack");
    }

    public override void UpdateState(AttackStateManager attack)
    {
        if (attack.TargetDetectment.closestCollider)
        {
            Attack(attack);
        }
    }

    public override void OnCollisionEnter(AttackStateManager attack, Collision collision)
    {
    }
}
