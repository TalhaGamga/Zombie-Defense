using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MarketController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UiManager.Instance.OpenMarket();
        }
    }
}
