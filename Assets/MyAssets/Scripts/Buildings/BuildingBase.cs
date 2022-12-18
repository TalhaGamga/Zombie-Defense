using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public abstract class BuildingBase :MonoBehaviour, IBuilding
{
    public List<GameObject> collisions;
    private void Awake()
    {
        collisions = new List<GameObject>();
    }
    public virtual void DoOperation()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        collisions.Add(collision.gameObject);
    }

    private void OnCollisionExit(Collision collision)
    {
        collisions.Remove(collision.gameObject);
    }
    
    public bool CheckCollisions()
    {
        return collisions.Count < 1;
    }

    public void Punch()
    {
        transform.DOPunchScale(Vector3.one, 0.5f, 10, 5);
    }
}
