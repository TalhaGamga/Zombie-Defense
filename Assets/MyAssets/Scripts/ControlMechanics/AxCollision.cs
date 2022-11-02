using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxCollision : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ZombieStats>(out ZombieStats stats))
        {
            stats.TakeDamage(damage);
        }
    }
}
