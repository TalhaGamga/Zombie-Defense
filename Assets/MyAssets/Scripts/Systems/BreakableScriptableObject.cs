using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BreakableSO")]
public class BreakableScriptableObject : ScriptableObject
{
    public BreakablePrice priceType;
    public float Hp;
}
