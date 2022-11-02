using System;
using UnityEngine;
public abstract class CharacterStats : StatBase
{

    //public int maxHealth = 100;
    //public float currentHealth { get; private set; }

    //public float currentHealth;
    public float armor;
    public float movementSpeed;
    public float reattackSpeed;
    public float damage;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public override void TakeDamage(float _damage)
    {
        _damage = Mathf.Clamp(_damage, 0, int.MaxValue);
        _damage -= armor;
        currentHealth -= _damage;

        ChangeToPct(currentHealth, maxHealth); //From StatBase

        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
