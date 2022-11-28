using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AttackBaseState 
{
    public abstract void EnterState(AttackStateManager attack);
    public abstract void UpdateState(AttackStateManager attack);
    public abstract void Attack(AttackStateManager attack);
    public abstract void OnCollisionEnter(AttackStateManager attack, Collision collision);
}
