using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuildingBase :MonoBehaviour, IBuilding
{
    [SerializeField]
    public List<GameObject> collisions;
    private void Awake()
    {
        collisions = new List<GameObject>();
    }

    public virtual void DoOperation()
    {
        throw new System.NotImplementedException();
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
        Debug.Log(collisions.Count);
        return collisions.Count < 1;
    }
}
