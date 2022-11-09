using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class StatBase : MonoBehaviour, IStat
{
    public event Action<float> OnHpPctChanged;

    public float maxHealth = 100;
    public float currentHealth;

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;

        ChangeToPct(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public void ChangeToPct(float currentHealth, float maxHealth)
    {
        OnHpPctChanged?.Invoke(currentHealth / maxHealth);
    }
}

