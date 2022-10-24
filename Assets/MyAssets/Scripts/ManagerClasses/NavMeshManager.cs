using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class NavMeshManager : Singleton<NavMeshManager>
{
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