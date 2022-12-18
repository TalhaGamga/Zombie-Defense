using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class AttackStateManager : MonoBehaviour
{
    public AttackBaseState currentState;
    public GunAttackState gunAttackState = new GunAttackState();
    public AxAttackState axAttackState = new AxAttackState();

    [Header("Ax Specials")]
    public GameObject ax;
    public AxCollision axCollision;
    public Rig axHolderRig;
    public AxProperties axProps;

    [Header("Gun Specials")]
    public GameObject gun;
    public Rig gunHolderRig;
    public Vector3 shootDir;
    public BulletController bulletController;
    public Transform firePoint;
    public GunProperties gunProps;

    [Header("Weapon Replecament Specials")]
    public GameObject parentPartOfBody;

    [Header("Current Attack State")]
    public AttackState attackState;

    [Header("General Weapon Props")]
    public float raTime;

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

    [SerializeField] private Animator anim;
    public Animator playerAnim
    {
        get
        {
            return anim;
        }
    }

    private void Start()
    {
        InitState(attackState);
    }

    public void Update()
    {
        currentState.UpdateState(this);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (attackState)
            {
                case AttackState.Gun:
                    SwitchState(AttackState.Ax);
                    break;

                case AttackState.Ax:
                    SwitchState(AttackState.Gun);
                    break;
                default:
                    break;
            }
        }
    }



    public void InitState(AttackState state)
    {
        switch (state)
        {
            case AttackState.Gun:
                attackState = AttackState.Gun;
                currentState = gunAttackState;
                currentState.EnterState(this);
                TargetDetectment.InitLockFunc(state);//
                break;

            case AttackState.Ax:
                attackState = AttackState.Ax;
                currentState = axAttackState;
                currentState.EnterState(this);
                TargetDetectment.InitLockFunc(state);//
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
                TargetDetectment.InitLockFunc(state);//
                currentState.EnterState(this);
                break;

            case AttackState.Ax:
                attackState = AttackState.Ax;
                currentState = axAttackState;
                TargetDetectment.InitLockFunc(state);//
                currentState.EnterState(this);
                break;
        }
    }

    public void GetProps(AttackState state)
    {
        switch (state)
        {
            case AttackState.Gun:
                firePoint = gunProps.firePoint;
                props = gunProps;
                break;

            case AttackState.Ax:
                firePoint = null;
                props = axProps;
                break;
        }

    }
    public void SetTargetDetecment()
    {
        TargetDetectment.range = props.range;
    }

    public BulletController CreateBullet()
    {
        BulletController bullet = Instantiate(bulletController, firePoint.position, transform.rotation);
        return bullet;
    }
}
