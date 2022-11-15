using UnityEngine;

public interface ICharacterAttackState 
{
    public void Attack(AttackStateManagerBase attack);
    public abstract void EnterState(AttackStateManagerBase attack);
    public abstract void UpdateState(AttackStateManagerBase attack);
    public abstract void OnCollisionEnter(AttackStateManagerBase attack, Collision collision);
}
 