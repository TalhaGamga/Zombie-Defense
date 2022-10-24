using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletController : MonoBehaviour
{
    //public Vector3 shootDir;
    float moveSpeed = 40f;

    public float damage;
    public Vector3 shootDir;
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    void Update()
    {
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }

    //public void Setup(Vector3 shootDir)
    //{
    //    this.shootDir = shootDir;
    //}

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.TryGetComponent(out ZombieStats zombieStats))
        {
            zombieStats.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    //    private void OnTriggerEnter(Collider collision)
    //    {
    //        if (collision.gameObject.TryGetComponent<ZombieStats>(out ZombieStats zombieStats))
    //        {
    //            Debug.Log("Deydi");
    //            zombieStats.TakeDamage(damage);
    //            Destroy(this.gameObject);
    //        }
    //    }

}
