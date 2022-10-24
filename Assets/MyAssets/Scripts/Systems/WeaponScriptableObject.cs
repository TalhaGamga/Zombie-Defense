using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponSO")]
public class WeaponScriptableObject : ScriptableObject
{
    public float range;
    public float reattackTime;
    public float damage;
    public float price;
    public string itemInfo;
    public Vector3 pickUpPos;
    public Vector3 pickupRot;
}
