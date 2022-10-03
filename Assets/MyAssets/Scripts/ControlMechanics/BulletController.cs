using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletController : MonoBehaviour
{
    private Vector3 shootDir;
    float moveSpeed = 40f;
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    //public void Setup(Vector3 shootDir)
    //{
    //    this.shootDir = shootDir;
        
    //}

    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ZombieController>(out ZombieController zombieController))
        {
            zombieController.Hit(1);
            Destroy(this.gameObject);
        }
    }
}
