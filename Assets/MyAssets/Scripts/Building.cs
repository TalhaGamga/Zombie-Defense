using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Building : MonoBehaviour
{

    [SerializeField]
    private float maxBuilding = 10;
    [SerializeField]
    private float currentBuilding;

    public event Action<float> OnBuildingPctChanged = delegate { };

    private void OnEnable()
    {
        currentBuilding = 0;
    }

    public void ModifyBuilding(float amount)
    {
        currentBuilding = amount;

        float currentBuildingPct = (float)currentBuilding / (float)maxBuilding;
        OnBuildingPctChanged(currentBuildingPct);
    }

    float timer = 0;

    private void OnCollisionStay(Collision collision)
    {
        if (timer < 10)
        {
            timer += Time.deltaTime;
            ModifyBuilding(timer);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        StopAllCoroutines();
    }

    private void OnCollisionExit(Collision collision)
    {
        StartCoroutine(IETimeController());
    }

    IEnumerator IETimeController()
    {
        while (timer > 0 && timer < maxBuilding / 2)
        {
            timer -= Time.deltaTime;
            ModifyBuilding(timer);
            yield return null;
        }

        while (timer > 5 && timer < maxBuilding)
        {
            timer -= Time.deltaTime;
            ModifyBuilding(timer);

            yield return null;
        }

        StopAllCoroutines();
    }

}
