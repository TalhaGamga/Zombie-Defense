using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DoorController : MonoBehaviour
{
    float maxHealth = 5;
    float currentHealth;

    [SerializeField] private ZombieSpawnManager zombieSpawnManager;
    [SerializeField] private GameObject touchBar;

    [SerializeField] private DoorState currentState;

    public event Action<float> OnHpPctChanged = delegate { };

    private void OnEnable()
    {
        currentState = DoorState.solid;
    }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            KillDoor();
        }
    }

    public void Hit(int hit)
    {
        if (currentState == DoorState.solid)
        {
            currentHealth -= hit;
            OnHpPctChanged(currentHealth / maxHealth);

            if (currentHealth < 1)
            {
                currentState = DoorState.broken;
                KillDoor();//error
            }
        }
    }

    void KillDoor()
    {
        zombieSpawnManager.OnSettingTarget?.Invoke(PlayerManager.Instance.player);
        //touchBar.SetActive(true);
        gameObject.SetActive(false);
    }
    //Door için gerekli fonksiyonlarý yaz ! ! !
}
