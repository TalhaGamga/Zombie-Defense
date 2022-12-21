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
        EventManager.OnStoppingGame?.Invoke();
        mainVirtualCamera.Priority = 8;
    }

    public void SwitchToPlayerFollowerCamera()
    {
        EventManager.OnPlayingGame?.Invoke();
        mainVirtualCamera.Priority = 11;
    }
}
