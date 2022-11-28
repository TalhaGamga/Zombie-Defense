using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AttackManagerAI : AttackStateManager
{
    private void Start()
    {
        InitState(attackState);
    } 

    public void Update()
    {
        currentState.UpdateState(this);
    }
}
