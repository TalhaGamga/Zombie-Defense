using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class EventManager
{
    public static Action OnStoppingGame;
    public static Action OnPlayingGame;

    public static Action<PriceType,float> OnSettingPrice;

    public static Func<PlayerManager> GetPlayer;
    public static Action<BuildingBase> OnReplaceBuilding;

    //public static Action OnBuildingWall;
} 
