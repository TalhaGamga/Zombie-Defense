using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class ZombieController : CharacterControllerBase
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<BuildingStatBase>(out BuildingStatBase buildingStatBase))
        {
            anim.SetTrigger("Attack");

        }
        if (collision.gameObject.TryGetComponent<CharacterStats>(out CharacterStats characterStats))
        {
            anim.SetTrigger("Attack");
        }
    }
} 