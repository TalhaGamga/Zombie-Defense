using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxController : MonoBehaviour
{
    [SerializeField] private Animator anim;

    public WeaponScriptableObject weaponSO;
    float timer = 0;
    float damage;

    [SerializeField] private Collider axCollider;

    TargetDetectment targetDetecment;
    TargetDetectment TargetDetecment
    {
        get
        {
            if (targetDetecment == null)
            {
                targetDetecment = GetComponentInParent<TargetDetectment>();
            }

            return targetDetecment;

        }
    }
    private void Awake()
    {
        TargetDetecment.range = weaponSO.range;

        damage = weaponSO.damage;

    }

    private void Update()
    {
        if (TargetDetecment.zombieColliders.Length > 0)
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("AxAttack");
        }
    }

    void Attack()
    {
        timer += Time.deltaTime;

        if (timer > weaponSO.reattackTime)
        {
            anim.SetTrigger("AxAttack");
            CallIEEnableCollider();
            timer = 0;
        }
    } 

    public void CallIEEnableCollider()
    {
        StartCoroutine(IEEnableAxCollider());
    }

    IEnumerator IEEnableAxCollider()
    {   
        axCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        axCollider.enabled = false;
    }

}
