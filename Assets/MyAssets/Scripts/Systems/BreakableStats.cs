using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BreakableStats : StatBase
{
    [SerializeField] private PriceTypeScriptableObject priceTypeSO;
    ObjectPooler objectPooler;
    [SerializeField] GameObject livingModel;
    [SerializeField] GameObject diedModel;
    private void Start()
    {
        priceType = priceTypeSO.priceType;
        currentHp = maxHp;

        objectPooler = ObjectPooler.Instance;
    }

    public override void Die()
    {
        objectPooler.CallCollectPrices(priceType.ToString(), transform.position, Quaternion.identity, collectPoint);
        //Destroy(gameObject);
        gameObject.layer = LayerMask.NameToLayer("Died");
        livingModel.SetActive(false);
        diedModel.SetActive(true);

        StartCoroutine(IEGrowUp());
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

    IEnumerator IEGrowUp()
    {
        yield return new WaitForSeconds(10f);
        transform.DOShakeScale(5, 0.05f,7,30,false);
        yield return new WaitForSeconds(5f);
        gameObject.layer = LayerMask.NameToLayer("Breakable");
        livingModel.SetActive(true);
        Revive();
        diedModel.SetActive(false);
    }
}
