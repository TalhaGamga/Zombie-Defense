using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HpBar : HpBarBase
{
    [SerializeField]
    private StatBase stats; 

    Camera mainCamera;
    private void Awake()
    {
        stats.OnHpPctChanged += HandleHpChanged;
    }   

    private void Start()
    {
        mainCamera = GameManager.Instance.mainCamera;
    }
    private void Update() 
    {
        transform.LookAt(mainCamera.transform.position);
    }
}
