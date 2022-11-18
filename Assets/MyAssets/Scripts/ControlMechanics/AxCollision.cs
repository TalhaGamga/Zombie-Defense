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
            stats.TakeDamage(damage);
            ContactPoint contact = collision.contacts[0];
            if (collision.gameObject.CompareTag("Zombie"))
            {

                Vector3 pushDir = (collision.transform.position - contact.point).normalized;
                pushDir.y = 0;
                collision.transform.DOMove(collision.transform.position + pushDir * 10f, 0.2f);
            }
        }
    }
}