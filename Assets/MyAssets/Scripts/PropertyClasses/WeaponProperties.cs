using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponProperties : MonoBehaviour
{
    public float range;
    public float reattackTime;
    public float damage;
    public float price;
    public string itemInfo;
    public Vector3 pickUpPos;
    public Vector3 pickUpRot;

    public WeaponScriptableObject weaponSO;

    private void OnEnable() 
    {
        range = weaponSO.range;
        reattackTime = weaponSO.reattackTime;
        damage = weaponSO.damage;
        price = weaponSO.price;
        itemInfo = weaponSO.itemInfo;
        pickUpPos = weaponSO.pickUpPos;
        pickUpRot = weaponSO.pickupRot;
    }
}
