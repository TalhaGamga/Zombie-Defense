using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("PlayerManager").AddComponent<PlayerManager>();
            }

            return instance;
        }
    }

     public GameObject player;

    private void OnEnable()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
