using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorStateManager : MonoBehaviour
{
    public DoorBaseState currentState;
    private SolidState solidState = new SolidState();
    private BrokenState brokenState = new BrokenState();

    public event Action<float> OnHpPctChanged = delegate { };

    [SerializeField] public DoorProperties doorProps;
    [SerializeField] public GameObject doorObj;

    [SerializeField] public ZombieSpawnManager zombieSpawnManager;

    public float timer = 0;
    Coroutine _IEOnBase;
    Coroutine _IELeftOnBase;

    private void OnEnable()
    {
        currentState = solidState;
    }
    private void Start()
    {
    }
    void Update()
    {

    }

    public void SwitchState(DoorState state)
    {
        switch (state)
        {
            case DoorState.solid:
                currentState = solidState;
                break;

            case DoorState.broken:
                currentState = brokenState;
                break;
        }
    }

    public void Hit(int hit) 
    {
        if (doorObj)
        {
            currentState.Hit(this, doorProps, hit, doorObj);
            OnHpPctChanged((doorProps.CurrentHp - hit) / doorProps.MaxHp);
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

    public void CallIEOnBase()
    {
        if (_IELeftOnBase != null)
        {
            StopCoroutine(_IELeftOnBase);
        }

        _IEOnBase = StartCoroutine(IEOnBase());
    }

    public void CallIELeftOnBase()
    {
        StopCoroutine(_IEOnBase);
        _IELeftOnBase = StartCoroutine(IELeftOnBase());
    }

    IEnumerator IEOnBase()
    {
        while (timer < doorProps.MaxHp)
        {
            timer += Time.deltaTime;
            doorProps.CurrentHp = timer;
            OnHpPctChanged(timer / doorProps.MaxHp);
            yield return null;
        }

        StopCoroutine(_IEOnBase);

        SwitchState(DoorState.solid);
        currentState.EnterState(this);
    }

    IEnumerator IELeftOnBase()
    {
        while (timer < doorProps.HalfHp && timer > 0)
        {
            timer -= Time.deltaTime;
            doorProps.CurrentHp = timer;
            OnHpPctChanged(timer / doorProps.MaxHp);
            yield return null;
        }

        while (timer > doorProps.HalfHp && timer < doorProps.MaxHp)
        {
            timer -= Time.deltaTime;
            doorProps.CurrentHp = timer;
            OnHpPctChanged(timer / doorProps.MaxHp);
            yield return null;
        }

        StopAllCoroutines();
    }
}
