using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public abstract class CollectableBase : MonoBehaviour, ICollectable
{
    [SerializeField] PriceTypeScriptableObject priceTypeSO;
    public virtual void Collect()
    {
        transform.SetParent(PlayerManager.Instance.collectPoint);
        transform.DOLocalMove(Vector3.zero, 0.5f).
        OnStepComplete(() =>
        {
            UiManager.Instance.SetPrice(priceTypeSO.priceType, 1);
            transform.SetParent(ObjectPooler.Instance.parent);
        }).
        OnComplete(() => gameObject.SetActive(false));
    }

    public void Use()
    {
        throw new System.NotImplementedException();
    }
}
