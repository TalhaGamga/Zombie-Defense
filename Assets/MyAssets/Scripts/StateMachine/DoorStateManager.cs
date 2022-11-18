using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorStateManager : MonoBehaviour
{
    public DoorBaseState currentState;
    private SolidState solidState = new SolidState();
    private BrokenState brokenState = new BrokenState();

    public GameObject doorObj;

    public ZombieSpawnManager zombieSpawnManager;

    [SerializeField]
    public DoorStats stats;

    public float timer = 0;

    Coroutine IEFix;

    public Transform interactPoint;
    private void OnEnable()
    {
        currentState = brokenState;
        currentState.EnterState(this);
    }
    private void Awake()
    {
        stats.OnSwitchState += SwitchState;
    }
    void Update()
    {

    }

    public void SwitchState(DoorState state)
    {
        switch (state)
        {
            case DoorState.Solid:
                currentState = solidState;
                currentState.EnterState(this);
                break;

            case DoorState.Broken:
                currentState = brokenState;
                currentState.EnterState(this);
                break;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
    public void OnCollisionExit(Collision collision)
    {
        currentState.OnCollisionExit(this, collision);
    }


    IEnumerator IEEnteredBase()
    {
        while (PlayerManager.Instance.priceDict[PriceType.Wood].currentPrice > 0 && stats.currentHp < stats.maxHp)
        {
            Collectable collectable = ObjectPooler.Instance.SpawnFromPool(PriceType.Wood.ToString(), PlayerManager.Instance.collectPoint.position, Quaternion.identity).GetComponent<Collectable>();
            collectable.PushToDoor(interactPoint, this);
            yield return new WaitForSeconds(.1f);
        }

        if (stats.currentHp == stats.maxHp)
        {
            SwitchState(DoorState.Solid);
            currentState.EnterState(this);
        }
    }


    public void CallIEEnteredBase()
    {
         IEFix = StartCoroutine(IEEnteredBase());
    }

    public void StopIEEnteredBase()
    {
        if (IEFix == null)
        {
            return;
        }

        StopCoroutine(IEFix);
        IEFix = null;
    }
}
