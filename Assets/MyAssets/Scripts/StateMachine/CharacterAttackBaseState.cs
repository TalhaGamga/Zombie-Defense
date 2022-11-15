using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CharacterAttackBaseState : ICharacterAttackState
{
    public abstract void EnterState(AttackStateManagerBase attack);
    public abstract void UpdateState(AttackStateManagerBase attack);
    public abstract void Attack(AttackStateManagerBase attack);
    public abstract void OnCollisionEnter(AttackStateManagerBase attack, Collision collision);
}
