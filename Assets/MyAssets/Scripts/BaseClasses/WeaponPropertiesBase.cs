using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class WeaponPropertiesBase : MonoBehaviour
{
    public AttackState state;

    public float range;
    public float reattackTime;
    public float damage;
    public float price;
    public string itemInfo;
    public Vector3 pickUpPos;
    public Quaternion pickUpRot;
    public Vector3 pickUpScale;

    public WeaponScriptableObject weaponSO;

    public void OnEnable()
    {
        state = weaponSO.state;
        range = weaponSO.range;
        reattackTime = weaponSO.reattackTime;
        damage = weaponSO.damage;
        price = weaponSO.price;
        itemInfo = weaponSO.itemInfo;
        pickUpPos = weaponSO.pickUpPos;
        pickUpRot = weaponSO.pickupRot;
        pickUpScale = weaponSO.pickUpScale;
    }

    public void Start()
    {
        transform.localPosition = pickUpPos;
        transform.localRotation = pickUpRot;
        transform.localScale = pickUpScale; 
    }
}
