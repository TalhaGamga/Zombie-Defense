using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ZombieStats : CharacterStats
{
    public override void Die()
    {
        base.Die();
        DropManager.Instance.DropGold(gameObject.transform);
    }
}
