using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AxCollision : MonoBehaviour
{
    public float damage;
    public Transform collectPoint;

    public Transform bag;

    Vector3 initScale;
    private void Awake()
    {
        initScale = bag.transform.localScale;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<StatBase>(out StatBase stats))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 shotDir = (collision.transform.position - contact.point).normalized;
            shotDir.y = 0;

            stats.shotDir = shotDir;
            stats.TakeDamage(damage);

            if (stats.priceType != PriceType.Gold)
            {
                stats.collectPoint = this.collectPoint;

                if (stats.currentHp <= 0)
                {
                    bag.transform.DOScale(initScale + Vector3.forward * 1 + Vector3.one*0.25f, 1f).OnStepComplete(() => bag.transform.DOScale(initScale, 1f));
                }
            }
        }
    }
}