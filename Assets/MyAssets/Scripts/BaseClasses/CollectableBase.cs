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
            //UiManager.Instance.SetPrice(priceTypeSO.priceType, 1);
            EventManager.OnSettingPrice(priceTypeSO.priceType, 1);
            transform.SetParent(ObjectPooler.Instance.parent);
        }).
        OnComplete(() => gameObject.SetActive(false));
    }

    public void PushToDoor(Transform target, DoorStateManager door)
    {
        PlayerManager.Instance.bagObj.DOPunchScale(Vector3.one * 0.1f, 0.1f, 1, 1);
        transform.DOLocalMove(target.position, 0.5f).

            OnStepComplete(() =>    
            {
                door.stats.currentHp++;
                door.stats.ChangeToPct(door.stats.currentHp, door.stats.maxHp);
            })

            .OnComplete(() => gameObject.SetActive(false));
        PlayerManager.Instance.priceDict[PriceType.Wood].SetPrice(-1);

    }
}
