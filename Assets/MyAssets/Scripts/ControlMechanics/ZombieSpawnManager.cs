using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ZombieSpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject target;
    [SerializeField] GameObject zombiePrefab;

    GameObject zombie;

    public Action<GameObject> OnSettingTarget;

    private void Awake()
    {
        
    }
    void Start()
    {
        StartCoroutine(SpawnZombie()); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnZombie()
    {
        for (int i = 0; i < 10; i++)
        {
            zombie = Instantiate(zombiePrefab, transform.position, Quaternion.identity, transform);

            yield return new WaitForSeconds(0.1f);
        }

        OnSettingTarget?.Invoke(target);
    }
}
