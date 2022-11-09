using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EquipmentShopItemController : MonoBehaviour
{

    private Vector3 pickUpPos;

    public float price;
    private string explanation;

    public TextMeshProUGUI infoText;
    public TextMeshProUGUI priceText;
    [SerializeField] private GameObject button;

    [SerializeField] WeaponScriptableObject weaponSO;
    [SerializeField] GameObject weaponPrefab;
    private void Awake()
    {
        pickUpPos = weaponSO.pickUpPos;
        price = weaponSO.price;
        explanation = weaponSO.itemInfo;

        infoText.text = explanation;
        priceText.text = price.ToString();
    }

    public void BuyWeapon()
    {
        //if (PlayerManager.Instance.gold > price)
        //{
        //    GameObject weapon = Instantiate(weaponPrefab, PlayerManager.Instance.player.transform);
        //    weapon.transform.localPosition = weaponSO.pickUpPos;

        //    Destroy(PlayerManager.Instance.equippedItem);

        //    PlayerManager.Instance.equippedItem = weapon;

        //    UiManager.Instance.SetGoldOnMarket(price);

        //    button.SetActive(false);
        //}
    }
}
