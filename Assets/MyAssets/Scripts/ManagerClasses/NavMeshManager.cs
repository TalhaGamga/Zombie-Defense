using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class NavMeshManager : MonoBehaviour
{
    private static NavMeshManager instance;
    public static NavMeshManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("NavMeshManager").AddComponent<NavMeshManager>();
            }

            return instance;
        }
    }

    
    private void OnEnable()
    {
        instance = this;
    }

    [SerializeField] private NavMeshSurface navMeshSurface;
    private void Start()
    {   
    } 

    void Update()
    {
    }

    public void BakeNavMesh()
    {
        navMeshSurface.BuildNavMesh(); //error
    }
}