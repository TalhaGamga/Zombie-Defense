using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DropManager : Singleton<DropManager>
{
    [SerializeField] GameObject goldPrefab;
    [SerializeField] GameObject woodPrefab;
    [SerializeField] GameObject stonePrefab;

    GameObject priceObj;
    public void DropPrice(PriceType price, Vector3 dropPos)
    {
        switch (price)
        {
            case PriceType.Gold:
                Instantiate(goldPrefab, dropPos, Quaternion.identity);
                break;

            case PriceType.Wood:
                CreatePrice(woodPrefab, dropPos);
                break;

            case PriceType.Stone:
                CreatePrice(stonePrefab, dropPos);
                break;
        }
    }

    void CreatePrice(GameObject objPref, Vector3 dropPos)
    {
        int randomNum = Random.Range(5, 15);

        for (int i = 0; i < randomNum; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle * 5;
            priceObj = Instantiate(objPref, dropPos, Quaternion.identity);
            priceObj.transform.DOJump(priceObj.transform.position + new Vector3(randomPoint.x, 0.1f, randomPoint.y), 3, 1, .7f).SetEase(Ease.OutBounce);
        }
    }
}
