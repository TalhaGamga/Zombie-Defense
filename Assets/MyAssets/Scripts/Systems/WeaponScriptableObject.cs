using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponSO")]
public class WeaponScriptableObject : ScriptableObject
{
    public AttackState state;
    public float range;
    public float reattackTime;
    public float damage;
    public float price;
    public string itemInfo;
    public Vector3 pickUpPos;
    public Quaternion pickupRot;
    public Vector3 pickUpScale;
}
