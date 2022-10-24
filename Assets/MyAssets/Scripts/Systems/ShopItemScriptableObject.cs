using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShopItemSO")]
public class ShopItemScriptableObject : ScriptableObject
{
    public string itemInfo;

    public float price;
}
 