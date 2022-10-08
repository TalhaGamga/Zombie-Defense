using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    private static DropManager instance;
    public static DropManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("PrizeManager").AddComponent<DropManager>();
            }

            return instance;
        }
    }

    private void OnEnable()
    {
        instance = this;
    }

    [SerializeField] GameObject goldPrefab;

    public void DropGold(Transform dropPos)
    {
        Instantiate(goldPrefab, dropPos.position, Quaternion.identity);
    }
}
