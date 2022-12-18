using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class StatBase : MonoBehaviour, IStat
{
    public PriceType priceType;
    public GameObject hpBarObj;
    public event Action<float> OnHpPctChanged;

    public float maxHp = 100;
    public float currentHp;

    public Vector3 shotDir;
    public Transform collectPoint;
    
    private void Awake()
    {
        currentHp = maxHp;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHp -= damage;

        ChangeToPct(currentHp, maxHp);

        if (currentHp <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        hpBarObj.SetActive(false);
        Destroy(this.gameObject);
    }

    public virtual void ChangeToPct(float currentHealth, float maxHealth)
    {
        OnHpPctChanged?.Invoke(currentHealth / maxHealth);
    }

    public void Revive()
    {
        currentHp = maxHp;
        ChangeToPct(currentHp, maxHp);
    }
}