using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BuildCreator : BuildingBase
{
    [SerializeField] BuildingStatBase building;
    [SerializeField] int collectedGold;
    [SerializeField] int collectedWood;
    [SerializeField] int collectedStone;

    [SerializeField] Transform collectPoint1;
    [SerializeField] Transform collectPoint2;
    [SerializeField] Transform collectPoint3;


    Coroutine BuildCor;

    [SerializeField] BuildBar buildBarGold;
    [SerializeField] BuildBar buildBarWood;
    [SerializeField] BuildBar buildBarStone;

    bool isOnPlane;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            isOnPlane = true;
            BuildCor = StartCoroutine(IE_Build());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerStats>(out PlayerStats  stats))
        {
            isOnPlane = false;

            if (BuildCor != null)
            {
                StopCoroutine(BuildCor);
            }
        }
    }
    IEnumerator IE_Build()
    {
        while (isOnPlane)
        {
            Build();
            yield return new WaitForSeconds(.1f);
        }
    }

    void Build()
    {
        if (PlayerManager.Instance.priceDict[PriceType.Gold].currentPrice > 0 && collectedGold < building.neededGold)
        {
            Collectable collectable = ObjectPooler.Instance.SpawnFromPool(PriceType.Gold.ToString(), PlayerManager.Instance.collectPoint.position, Quaternion.identity).GetComponent<Collectable>();
            collectable.Push(collectPoint1, -1);
            collectedGold++;
            buildBarGold.HandleHpChanged(collectedGold / building.neededGold);
        }

        if (PlayerManager.Instance.priceDict[PriceType.Wood].currentPrice > 0 && collectedWood < building.neededWood)
        {
            Collectable collectable = ObjectPooler.Instance.SpawnFromPool(PriceType.Wood.ToString(), PlayerManager.Instance.collectPoint.position, Quaternion.identity).GetComponent<Collectable>();
            collectable.Push(collectPoint2, -1);
            collectedWood++;
            buildBarWood.HandleHpChanged(collectedWood / building.neededWood);
        }

        if (PlayerManager.Instance.priceDict[PriceType.Stone].currentPrice > 0 && collectedStone < building.neededStone)
        {
            Collectable collectable = ObjectPooler.Instance.SpawnFromPool(PriceType.Stone.ToString(), PlayerManager.Instance.collectPoint.position, Quaternion.identity).GetComponent<Collectable>();
            collectable.Push(collectPoint3, -1);
            collectedStone++;
            buildBarStone.HandleHpChanged(collectedStone / building.neededStone);
        }

        if (collectedStone >= building.neededStone && collectedGold >= building.neededGold && collectedWood >= building.neededWood)
        {
            Instantiate(building.gameObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}