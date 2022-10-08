using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 100 * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int goldNum = Random.Range(1, 5);
            PlayerManager.Instance.gold += goldNum;
            UiManager.Instance.SetGoldText();
            UiManager.Instance.CallIEPlayPopUpGold(goldNum);
            Destroy(gameObject);
        }
    }
}
