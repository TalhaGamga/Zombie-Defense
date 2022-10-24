using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeaponController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private BulletController bulletController;

    float timer = 0;

    public WeaponScriptableObject weaponSO;
    Vector3 shootDir;
    //[SerializeField] private Transform firePoint;

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


    }

    private void Update()
    {
        if (TargetDetecment.targetColliders.Length > 0)
        {
            Fire();
        }
    }

    void Fire()
    {
        timer += Time.deltaTime;

        if (timer > weaponSO.reattackTime)
        {
            BulletController bullet = Instantiate(bulletController, transform.position, transform.rotation);
            shootDir = (TargetDetecment.targetPos.position - transform.position).normalized;
            bullet.shootDir = shootDir;
            bullet.damage = weaponSO.damage;
            timer = 0;
        }
    }
}
