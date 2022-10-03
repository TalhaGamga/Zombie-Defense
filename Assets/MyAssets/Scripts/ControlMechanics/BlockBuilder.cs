using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BlockBuilder : MonoBehaviour
{
    [SerializeField]
    private float maxHp = 10;
    [SerializeField]
    private float currentHp;

    float halfBuilding;

    public event Action<float> OnBuildingPctChanged = delegate { };

    float timer = 0;

    Coroutine _IEOnBase;
    Coroutine _IELeftOnBase;

    [SerializeField] private GameObject door;

    private void OnEnable()
    {
        currentHp = maxHp;
        halfBuilding = maxHp / 2;
    }

    public void ModifyBuilding(float amount)
    {
        currentHp = amount;

        float currentBuildingPct = (float)currentHp / (float)maxHp;
        OnBuildingPctChanged(currentBuildingPct);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Movement>(out Movement movement))
        {
            if (_IELeftOnBase != null)
            {
                StopCoroutine(_IELeftOnBase);
            }

            _IEOnBase = StartCoroutine(IEOnBase());
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Movement>(out Movement movement))
        {

            if (_IEOnBase != null)
            {
                StopCoroutine(_IEOnBase);
            }

            _IELeftOnBase = StartCoroutine(IELeftOnBase());

            StopCoroutine(_IEOnBase);
        }
    }
      
    IEnumerator IEOnBase()
    {
        while (timer < maxHp)
        {
            timer += Time.deltaTime;
            ModifyBuilding(timer);

            yield return null;
        }
        Debug.Log("doldu");

        door.gameObject.SetActive(true);
    }

    IEnumerator IELeftOnBase()
    {
        while (timer < halfBuilding && timer > 0)
        {
            timer -= Time.deltaTime;
            ModifyBuilding(timer);

            yield return null;
        }

        while (timer > halfBuilding && timer < maxHp)
        {
            timer -= Time.deltaTime;
            ModifyBuilding(timer);
            yield return null;
        }

        StopCoroutine(_IEOnBase);
    }
}
