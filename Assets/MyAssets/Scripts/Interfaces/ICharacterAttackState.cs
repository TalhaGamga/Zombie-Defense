using UnityEngine;

public interface ICharacterAttackState 
{
    public void Attack(AttackStateManager attack);
    public abstract void EnterState(AttackStateManager attack);
    public abstract void UpdateState(AttackStateManager attack);
    public abstract void OnCollisionEnter(AttackStateManager attack, Collision collision);
}
 