using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorProperties : MonoBehaviour
{
    [SerializeField]
    private float _maxHp = 5f;
    [SerializeField]
    private float _currentHp;
    private float _halfHp;
    
    private void OnEnable()
    {
        _currentHp = _maxHp;
        _halfHp = _maxHp / 2;
    }
    public float MaxHp
    {
        get
        {
            return _maxHp;
        }
    }

    public float CurrentHp
    {
        get
        {
            return _currentHp;
        }

        set
        {
            _currentHp = value;
        }
    }

    public float HalfHp
    {
        get
        {
            return _halfHp;
        }
    }
}
