using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem : MonoBehaviour
{

    [SerializeField] BuildingStatBase stats;
    [SerializeField] BuildingBase buildCreator;
    
    [SerializeField] SnapBuilding snap;

    float neededGold;

    public void PurchaseBuilding()
    {
        neededGold = stats.neededGold;
        Debug.Log(neededGold);
        if (PlayerManager.Instance.priceDict[PriceType.Gold].currentPrice >= stats.neededGold)
        {
            UiManager.Instance.SetPrice(PriceType.Gold, -neededGold);
            snap.CallIEDragBuilding(buildCreator);
        }
    }
}
