using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSlot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bulletPrefab;

    float timer = 0;

    private void OnEnable()
    {
        FireController.OnTargetDetected += Fire;
    }
    private void OnDisable()
    {
        FireController.OnTargetDetected -= Fire;
    }
    void Fire()
    {
        timer += Time.deltaTime;

        if (timer > .2f)
        {
            Vector3 shootDir = transform.forward;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            timer = 0;
        }
    }

}
