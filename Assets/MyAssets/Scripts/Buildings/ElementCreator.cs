using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementCreator : BuildingBase
{
    [SerializeField] int elementCreationLimit = 300;
    [SerializeField] int createdElementNum = 0;

    [SerializeField] PriceTypeScriptableObject priceSO;

    [SerializeField] SkinnedMeshRenderer skinnedMesh;

    private void Start()
    {
        Punch();
        DoOperation();  
    }
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
            EventManager.OnSettingPrice(PriceType.Gold, 3);
        }
    }
}
