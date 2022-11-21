using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveIncomeFactory : BuildingBase
{
    [SerializeField] int elementCreationLimit = 300;
    [SerializeField] int createdElementNum = 0;

    [SerializeField] PriceTypeScriptableObject priceSO;

    public override void DoOperation()
    {
        StartCoroutine(IEPasiveIncome());
    }

    IEnumerator IEPasiveIncome()
    {
        while (createdElementNum < elementCreationLimit)
        {
            yield return new WaitForSeconds(3f);
            createdElementNum += 3;
            //EventManager.OnSettingPrice(PriceType.Gold, 3);
        }
    }

    public void FetchElementsToEnvanter()
    {
        EventManager.OnSettingPrice(priceSO.priceType, createdElementNum);
    }
}
