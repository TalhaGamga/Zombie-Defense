using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : HpBarBase
{
    [SerializeField]
    private StatBase stats;

    private StatBase Stats
    {
        get
        {
            if (stats == null)
            {
                stats = GetComponentInParent<StatBase>();
            }

            return stats;
        }
    }

    private void Awake()
    {
        Stats.OnHpPctChanged += HandleHpChanged;
    }
}
