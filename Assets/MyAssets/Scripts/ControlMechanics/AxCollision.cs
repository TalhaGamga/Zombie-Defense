using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxCollision : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<StatBase>(out StatBase stats))
        {
            if (stats.gameObject == PlayerManager.Instance.player)
            {
                return;
            }

            stats.TakeDamage(damage);
        }
    }
}