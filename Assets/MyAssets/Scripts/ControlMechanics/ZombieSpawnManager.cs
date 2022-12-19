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
        yield return new WaitForSeconds(10f);
        for (int i = 0; i < 10; i++)
        {   
            zombie = ObjectPooler.Instance.SpawnFromPool("Zombie", transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(20f);
        StartCoroutine(SpawnZombie());
    }



}
