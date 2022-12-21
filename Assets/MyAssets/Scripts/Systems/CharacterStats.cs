using System;
using System.Collections;
using UnityEngine;
public class CharacterStats : StatBase
{
    //public int maxHealth = 100;
    //public float currentHealth { get; private set; }

    //public float currentHealth;
    public float speedMultier = 1;
    public float armor;
    public float movementSpeed;
    public float reattackSpeed;
    public float damage;

    //private void Awake()
    //{
    //    currentHp = maxHp;
    //}

    public override void TakeDamage(float _damage)
    {
        _damage = Mathf.Clamp(_damage, 0, int.MaxValue);
        _damage -= armor;
        Debug.Log(_damage);
        currentHp -= _damage;

        ChangeToPct(currentHp, maxHp); //From StatBase

        if (currentHp <= 0)
        {
            Die();
        }
    }
}
