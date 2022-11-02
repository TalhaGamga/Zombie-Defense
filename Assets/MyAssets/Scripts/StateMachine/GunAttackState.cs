using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttackState : CharacterAttackBaseState
{
    float timer;
    float reattackTime;
    public override void EnterState(AttackStateManager attack)
    {
        attack.axHolderRig.weight = 0;
        attack.gunHolderRig.weight = 1;

        attack.ax.SetActive(false);
        attack.axCollision.gameObject.SetActive(false);

        attack.gun.SetActive(true);

        attack.GetProps(attack.attackState);
        attack.SetTargetDetecment();

        reattackTime = attack.props.reattackTime;

        timer = 0;
    }

    public override void Attack(AttackStateManager attack)
    {
        timer += Time.deltaTime;
        if (timer > reattackTime)
        {
            BulletController bullet = attack.CreateBullet();
            bullet.damage = attack.props.damage;
            bullet.shootDir = GetShootDir(attack);
            timer = 0;
        }
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
        //if (collision.gameObject.TryGetComponent<>)
        //{

        //}
    }

    public Vector3 GetShootDir(AttackStateManager attack)
    {
        attack.shootDir = (attack.TargetDetectment.targetPos.position - attack.firePoint.position).normalized;
        return attack.shootDir;
    }
}

