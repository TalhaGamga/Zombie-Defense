using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class AttackStateManager : MonoBehaviour
{
    public CharacterAttackBaseState currentState;
    public GunAttackState gunAttackState = new GunAttackState();
    public AxAttackState axAttackState = new AxAttackState();

    [Header("Ax Specials")]
    public GameObject ax;
    public AxCollision axCollision;
    public Rig axHolderRig;

    [Header("Gun Specials")]
    public GameObject gun;
    public Rig gunHolderRig;
    public Vector3 shootDir;
    public BulletController bulletController;
    public Transform firePoint;

    [Header("Weapon Replecament Specials")]
    public GameObject parentPartOfBody;

    [Header("Current Attack State")]
    public AttackState attackState;

    [Header("General Weapon Props")]
    public float raTime;


    public Animator playerAnim
    {
        get
        {
            return GetComponentInChildren<Animator>();
        }
    }

    [Header("Props")]
    public WeaponPropertiesBase props;

    private TargetDetectment targetDetectment;
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

    private void Start()
    {
        InitState(AttackState.Ax);
    }

    private void Update()
    {
        currentState.UpdateState(this);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (attackState)
            {
                case AttackState.Gun:
                    SwitchState(AttackState.Ax);
                    currentState.EnterState(this);
                    break;

                case AttackState.Ax:
                    SwitchState(AttackState.Gun);
                    currentState.EnterState(this);
                    break;
            }
        }
    }

    private void InitState(AttackState state)
    {
        switch (state)
        {
            case AttackState.Gun:
                attackState = AttackState.Gun;
                currentState = gunAttackState;
                currentState.EnterState(this);


                break;

            case AttackState.Ax:
                attackState = AttackState.Ax;
                currentState = axAttackState;
                currentState.EnterState(this);


                break;
        }
    }

    public void SwitchState(AttackState state)
    {
        switch (state)
        {
            case AttackState.Gun:
                attackState = AttackState.Gun;
                currentState = gunAttackState;
                currentState.EnterState(this);
                break;

            case AttackState.Ax:
                attackState = AttackState.Ax;
                currentState = axAttackState;
                currentState.EnterState(this);
                break;
        }
    }

    public void GetProps(AttackState state)
    {
        switch (state)
        {
            case AttackState.Gun:
                GunProperties gunProps = GetComponentInChildren<GunProperties>();
                firePoint = gunProps.firePoint;
                props = gunProps;
                break;

            case AttackState.Ax:
                firePoint = null;
                props = GetComponentInChildren<AxProperties>();
                break;
        }

    }
    public void SetTargetDetecment()
    {
        TargetDetectment.attackRange = props.range;
    }
    public void CallEnableAxCollider()
    {
        StartCoroutine(IEActivateAxCollider());
    }

    IEnumerator IEActivateAxCollider()
    {
        axCollision.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        axCollision.gameObject.SetActive(false);
    }

    public BulletController CreateBullet()
    {
        BulletController bullet = Instantiate(bulletController, firePoint.position, transform.rotation);
        return bullet;
    } 
}