using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class ZombieController : CharacterControllerBase
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<BuildingStatBase>(out BuildingStatBase buildingStatBase))
        {
            anim.SetBool("_Attack", true);

        }
        if (collision.gameObject.TryGetComponent<CharacterStats>(out CharacterStats characterStats))
        {
            anim.SetBool("_Attack",true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<BuildingStatBase>(out BuildingStatBase buildingStatBase))
        {
            anim.SetBool("_Attack", false);
             
        }
        if (collision.gameObject.TryGetComponent<CharacterStats>(out CharacterStats characterStats))
        {
            anim.SetBool("_Attack", false);
        }
    }
} 