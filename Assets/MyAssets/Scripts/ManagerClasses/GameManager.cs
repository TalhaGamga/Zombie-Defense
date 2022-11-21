using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : Singleton<GameManager>
{
    public  Camera mainCamera;
    public CinemachineVirtualCamera mainVirtualCamera;
    public Transform snappingCamPos;
    public void SwitchToBuildingCamera()
    { 
        mainVirtualCamera.Priority = 8;
        EventManager.OnStoppingGame?.Invoke();
    }

    public void SwitchToPlayerFollowerCamera()
    {
        mainVirtualCamera.Priority = 11;
        EventManager.OnPlayingGame?.Invoke();
    }
}
