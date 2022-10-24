using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : Singleton<DropManager>
{
    [SerializeField] GameObject goldPrefab;
    public void DropGold(Transform dropPos)
    {
        Instantiate(goldPrefab, dropPos.position, Quaternion.identity);
    }
}
