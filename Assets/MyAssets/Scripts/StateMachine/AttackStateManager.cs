using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateManager : MonoBehaviour
{
    public CharacterAttackBaseState currentState;
    public GunAttackState gunAttackState = new GunAttackState();
    public AxAttackState axAttackState = new AxAttackState();

    [SerializeField] GameObject axCollider;
    public Animator playerAnim
    {
        get
        {
            return GetComponentInChildren<Animator>();
        }
    }

    public WeaponProperties props;
    public TargetDetectment targetDetectment;
    public TargetDetectment TargetDetectment
    {
        get
        {
            if (targetDetectment == null)
            {
                targetDetectment = GetComponent<TargetDetectment>();
            }
            return targetDetectment;
        }
    }

    private void OnEnable()
    {
        currentState = axAttackState;
        GetProps();
        SetTargetDetecment();
        GetProps();
    }

    private void Update()
    {
        currentState.UpdateState(this);

        if (Input.GetKeyDown(KeyCode.F))
        {
            currentState.Attack(this, props);
        }
    }

    public void SwitchState(AttackState state)
    {
        switch (state)
        {
            case AttackState.gun:
                currentState = gunAttackState;
                break;

            case AttackState.Ax:
                currentState = axAttackState;
                break;
        }
    }

    public void GetProps()
    {
        props = GetComponentInChildren<WeaponProperties>();
    }

    public void Attack()
    {
        currentState.Attack(this, props);
    }

    public void SetTargetDetecment()
    {
        TargetDetectment.range = props.range;
    }

    //This function is called by ax animation.
    public void CallEnableAxCollider()
    {
        StartCoroutine(IEActivateAxCollider());
    }

    IEnumerator IEActivateAxCollider()
    {
        axCollider.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        axCollider.SetActive(false);

    }

}
