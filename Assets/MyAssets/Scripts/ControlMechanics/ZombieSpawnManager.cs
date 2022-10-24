using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ZombieSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject doorTargetPoint;
    [SerializeField] GameObject zombiePrefab;

    [SerializeField] DoorStateManager doorStateManager;

    GameObject zombie;

    public Action<GameObject> OnSettingTarget;


    void Start()
    {
        StartCoroutine(SpawnZombie());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnZombie());
        }
    }

    IEnumerator SpawnZombie()
    {
        for (int i = 0; i < 10; i++)
        {
            zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(0.1f);
        }

        if (doorStateManager.doorProps.CurrentHp > 0)
        {
            OnSettingTarget?.Invoke(doorTargetPoint); //Make here automatic (target setter etc.)
        }

        else
        {
            OnSettingTarget?.Invoke(PlayerManager.Instance.player);
        }

    }
}
