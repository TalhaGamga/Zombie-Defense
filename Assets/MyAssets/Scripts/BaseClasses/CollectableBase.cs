using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public abstract class CollectableBase : MonoBehaviour, ICollectable
{
    [SerializeField] PriceTypeScriptableObject priceTypeSO;

    public virtual void Collect(Transform parent) 
    {
        transform.SetParent(parent);
        transform.DOLocalMove(Vector3.zero, 0.3f).
        OnComplete(() =>
        {
            EventManager.OnSettingPrice(priceTypeSO.priceType, 1);
            transform.SetParent(ObjectPooler.Instance.parent); 
        }).
        OnStepComplete(()=>gameObject.transform.SetParent(null)).
        OnStepComplete(() => gameObject.SetActive(false));
    }

    public void PushToDoor(Transform target, DoorStateManager door)
    {
        transform.DOLocalMove(target.position, 0.5f).

            OnStepComplete(() =>    
            {
                door.stats.currentHp++;
                door.stats.ChangeToPct(door.stats.currentHp, door.stats.maxHp);
            })

            .OnComplete(() => gameObject.SetActive(false));
        PlayerManager.Instance.priceDict[PriceType.Wood].SetPrice(-1);
    }

    public void Push(Transform target, int num)
    {
        transform.DOLocalMove(target.position, 0.5f).
            OnComplete(() => gameObject.SetActive(false));

        EventManager.OnSettingPrice(priceTypeSO.priceType, num);
    }
}
