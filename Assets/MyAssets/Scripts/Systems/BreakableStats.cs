using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BreakableStats : StatBase
{
    [SerializeField] private PriceTypeScriptableObject priceTypeSO;

    PriceType priceType;
    ObjectPooler objectPooler;

    Transform collectPoint;
    private void Start()
    {
        priceType = priceTypeSO.priceType;
        currentHp = maxHp;

        objectPooler = ObjectPooler.Instance;
        collectPoint = PlayerManager.Instance.collectPoint;
    }

    public override void Die()
    {
        objectPooler.CallCollectPrices(priceType.ToString(), transform.position, Quaternion.identity, collectPoint);
        Destroy(gameObject);
    }

    public override void TakeDamage(float damage)
    {
        currentHp -= damage;

        ChangeToPct(currentHp, maxHp);

        Vector3 preScale = transform.localScale;

        transform.DOScale(preScale + Vector3.one * 0.2f, .1f).OnComplete(() => transform.DOScale(preScale, .1f));

        if (currentHp <= 0)
        {
            Die();
        }
    }
}
