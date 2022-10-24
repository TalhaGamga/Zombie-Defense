using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UiUpgradeManager : MonoBehaviour
{
    [SerializeField] private CharacterStats stats;

    public void MovementSpeedUp()
    {
        stats.movementSpeed.SetValue(stats.movementSpeed.GetValue() * 1.2f);
    }

    public void AttackSpeedUp()
    {
        stats.reattackSpeed.SetValue(stats.reattackSpeed.GetValue() * 0.8f);
    }

    public void AttackPowerUp()
    {
        float previousDmg = PlayerManager.Instance.stats.damage.GetValue();
        PlayerManager.Instance.stats.damage.SetValue(previousDmg * 1.2f);
    }
}
