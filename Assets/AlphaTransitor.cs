using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlphaTransitor : MonoBehaviour
{
    [SerializeField] SpriteRenderer _renderer;
    Color initColor;

    private void Start()
    {
        initColor = _renderer.material.color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _renderer.material.DOColor(initColor * 1.6f, 0.5f);
        }
    }

    private void OnCollisionExit(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _renderer.material.DOColor(initColor, 0.5f);
        }
    }
}
