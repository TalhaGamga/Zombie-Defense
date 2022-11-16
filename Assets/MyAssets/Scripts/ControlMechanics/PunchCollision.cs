using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchCollision : MonoBehaviour
{
    [SerializeField] CharacterStats stats;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<BuildingStatBase>(out BuildingStatBase buildingStatBase))
        {
            buildingStatBase.TakeDamage(stats.damage);
        }
        if (collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats playerStats))
        {
            playerStats.TakeDamage(stats.damage);
        }
    }
}
