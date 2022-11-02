using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UiUpgradeManager : MonoBehaviour
{
    [SerializeField] private CharacterStats stats;

    public void MovementSpeedUp()
    {
        stats.movementSpeed=(stats.movementSpeed * 1.2f);
    }

    public void AttackSpeedUp()
    {
        stats.reattackSpeed=(stats.reattackSpeed * 0.8f);
    }
     
    public void AttackPowerUp()
    {
        float previousDmg = PlayerManager.Instance.stats.damage;
        PlayerManager.Instance.stats.damage=previousDmg * 1.2f;
    }
}
