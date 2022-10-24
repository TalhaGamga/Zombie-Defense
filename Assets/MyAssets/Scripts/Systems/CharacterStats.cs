using System;
using UnityEngine;
public abstract class CharacterStats : MonoBehaviour
{
    public event Action<float> OnHpPctChanged = delegate { };

    public int maxHealth = 100;
    //public float currentHealth { get; private set; }

    public Stat currentHealth;
    public Stat armor;
    public Stat movementSpeed;
    public Stat reattackSpeed;
    public Stat damage;
    private void Awake()
    {
        currentHealth.SetValue(maxHealth);
    }
     
    public virtual void TakeDamage(float _damage)
    {
       
        _damage = Mathf.Clamp(_damage, 0, int.MaxValue);
        _damage -= armor.GetValue();
        float hp = currentHealth.GetValue();
        
        currentHealth.SetValue(hp - _damage);        
         
        OnHpPctChanged?.Invoke(currentHealth.GetValue()/maxHealth);

        if (currentHealth.GetValue() <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
