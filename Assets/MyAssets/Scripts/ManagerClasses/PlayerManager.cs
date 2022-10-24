using UnityEngine;
using System;
public class PlayerManager : Singleton<PlayerManager>
{
    public Action OnPanelOpenedOrClosed;

    public PlayerStats stats;

    public float gold = 0;
    public GameObject player;
    public GameObject equippedItem;
}
