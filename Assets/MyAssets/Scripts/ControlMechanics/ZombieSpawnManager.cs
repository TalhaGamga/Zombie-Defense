using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ZombieSpawnManager : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;

    GameObject zombie;

    public Action<GameObject> OnSettingTarget;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {

        //StartCoroutine(SpawnZombie());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnZombie());
        }
    }
    IEnumerator SpawnZombie()
    {
        //yield return new WaitForSeconds(10f);
        for (int i = 0; i < 10; i++)
        {
            zombie = ObjectPooler.Instance.SpawnFromPool("Zombie", transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
        //yield return new WaitForSeconds(20f);
        //StartCoroutine(SpawnZombie());
    }
}
