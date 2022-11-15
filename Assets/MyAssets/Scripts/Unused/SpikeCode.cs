using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeCode : MonoBehaviour
{
    //public void CallIEOnBase()
    //{
    //    if (_IELeftOnBase != null)
    //    {
    //        StopCoroutine(_IELeftOnBase);
    //    }

    //    _IEOnBase = StartCoroutine(IEOnBase());
    //}

    //public void CallIELeftOnBase()
    //{
    //    StopCoroutine(_IEOnBase);
    //    _IELeftOnBase = StartCoroutine(IELeftOnBase());
    //}

    //IEnumerator IEOnBase()
    //{
    //    while (timer < stats.maxHp)
    //    {
    //        timer += Time.deltaTime;
    //        stats.currentHp= timer;
    //        OnHpPctChanged(timer / stats.maxHp);
    //        yield return null;
    //    }

    //    StopCoroutine(_IEOnBase);

    //    SwitchState(DoorState.Solid);
    //    currentState.EnterState(this);
    //}

    //IEnumerator IELeftOnBase()
    //{
    //    StopCoroutine(IEOnBase());
    //    while (timer < doorProps.HalfHp && timer > 0)
    //    {
    //        timer -= Time.deltaTime;
    //        doorProps.CurrentHp = timer;
    //        OnHpPctChanged(timer / doorProps.MaxHp);
    //        yield return null;
    //    }

    //    while (timer > doorProps.HalfHp && timer < doorProps.MaxHp)
    //    {
    //        timer -= Time.deltaTime;
    //        doorProps.CurrentHp = timer;
    //        OnHpPctChanged(timer / doorProps.MaxHp);
    //        yield return null;
    //    }
    //    StopAllCoroutines();
    //}

}
