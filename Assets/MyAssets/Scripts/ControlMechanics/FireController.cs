using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FireController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float radius;

    //[SerializeField] private Animator playerAnim;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    float timer = 0f;

    Collider closestCollider;

    public static Action OnTargetDetected;

    void Start()
    {
        //playerAnim = GetComponentInChildren<Animator>();
    }

    public Collider[] colliders;
    Collider tempCollider;

    void Update()
    {
        DetectTarget(); 

        if (colliders.Length > 0)
        {
            OnTargetDetected?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void DetectTarget()
    {
        if (FindClosestCollider() != null)
        {
            transform.LookAt(FindClosestCollider().transform.position);
            Debug.DrawLine(FindClosestCollider().transform.position, transform.position, Color.red, 0f, true);
        }
    }

    Collider FindClosestCollider()
    {
        if (colliders.Length > 0)
        {
            tempCollider = colliders[0];
        }

        foreach (Collider collider in colliders)
        {
            if (collider != null)
            {
                if (Vector3.Distance(collider.transform.position, transform.position) < Vector3.Distance(tempCollider.transform.position, transform.position))
                {
                    tempCollider = collider;
                }
            }
        }

        closestCollider = tempCollider;
        return closestCollider;
    }
    //void Fire()
    //{
    //    if (colliders.Length > 0)
    //    {
    //        timer += Time.deltaTime;

    //        if (timer > .2f)
    //        {
    //            Vector3 shootDir = transform.forward;
    //            Debug.Log(shootDir);
    //            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
    //            //bullet.GetComponent<BulletController>().Setup(shootDir);
    //            timer = 0;
    //        }
    //    }
    //}
}
