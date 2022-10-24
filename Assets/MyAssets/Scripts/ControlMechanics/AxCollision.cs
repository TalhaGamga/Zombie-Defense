using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxCollision : MonoBehaviour
{
    [SerializeField] private WeaponScriptableObject axSO;
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Deydi");
        if (collision.gameObject.TryGetComponent<ZombieStats>(out ZombieStats stats))
        {
            Debug.Log(11);
            stats.TakeDamage(axSO.damage);
        }
    }
}
