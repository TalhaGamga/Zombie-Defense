using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HumanoidHpBar : MonoBehaviour
{
    [SerializeField]
    private Image foregroundImage;

    [SerializeField]
    private CharacterStats stats;

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

    private void HandleHpChanged(float pct)
    {
        ChangeToPct(pct);
    }

    private void ChangeToPct(float pct)
    {
        float preChangePct = foregroundImage.fillAmount;
        foregroundImage.fillAmount = pct;
    }
}
