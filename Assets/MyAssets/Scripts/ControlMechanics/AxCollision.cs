using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AxCollision : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<StatBase>(out StatBase stats))
        {

            ContactPoint contact = collision.contacts[0];
            Vector3 shotDir = (collision.transform.position - contact.point).normalized;
            shotDir.y = 0;

            stats.shotDir = shotDir;
            stats.TakeDamage(damage);
        }
    }
}