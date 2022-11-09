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

    Camera mainCamera;

    private void Awake()
    {
        Stats.OnHpPctChanged += HandleHpChanged;
    }

    private void Start()
    {
        mainCamera = GameManager.Instance.mainCamera;
    }
    private void Update()
    {
        Vector3 direction = (mainCamera.transform.position - transform.position).normalized;
        transform.forward = new Vector3(0, direction.y, direction.z);
    }
}
