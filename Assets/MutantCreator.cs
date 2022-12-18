using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantCreator : BuildingBase
{
    [SerializeField] BuildingStats stats;
    [SerializeField] SupportAIController aiController;
    [SerializeField] Transform initPoint;
    private void Start()
    {
        Punch();
        DoOperation();
    }

    public override void DoOperation()
    {
        StartCoroutine(IECreateMutant());
    }

    IEnumerator IECreateMutant()
    {
        while (stats.currentHp>0)
        {
            yield return new WaitForSeconds(20f);
            Instantiate(aiController, initPoint.position, Quaternion.identity);
        }
    }
}
