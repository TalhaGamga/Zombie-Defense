using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GemController : MonoBehaviour
{
    float price;
    void Start()
    {
        price = Random.Range(1, 10);
        StartCoroutine(DestroyGem());
    }

    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //UiManager.Instance.SetPriceOnCollect(price);
            //UiManager.Instance.CallIEPlayPopUpGold(price);
            UiManager.Instance.SetPrice(PriceType.Gold, price);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyGem()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }
}
