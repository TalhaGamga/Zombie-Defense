using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableStats : StatBase
{
    [SerializeField] private BreakableScriptableObject breakableSO;
    [SerializeField] private float price;

    void OnEnable()
    {
        maxHealth = breakableSO.Hp;
    }

    public override void Die()
    {
        base.Die();

        //Drop Price
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            base.TakeDamage(10);
        }
    }
}
