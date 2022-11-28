using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAttackState : AttackBaseState
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
        PlayerManager.Instance.stats.speedMultier=1.25f;
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
        attack.shootDir = (attack.TargetDetectment.crossPos.position - attack.firePoint.position + Vector3.up).normalized;
        return attack.shootDir;
    }
}

