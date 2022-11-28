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
            buildingStatBase.TakeDamage(stats.damage / 5);
        }
        if (collision.gameObject.TryGetComponent<HumanStats>(out HumanStats humanStats))
        {
            humanStats.TakeDamage(stats.damage);
        }
    }
}
