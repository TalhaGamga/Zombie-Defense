using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBuilding : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private LayerMask groundLayer;

    BuildingBase _building;

    private void OnEnable()
    {
        EventManager.OnReplaceBuilding += CallIEDragBuilding;
    }

    private void OnDisable()
    {
        EventManager.OnReplaceBuilding -= CallIEDragBuilding;
    }

    IEnumerator IEDragBuilding(BuildingBase building)
    {
        EventManager.OnStoppingGame();
        GameManager.Instance.SwitchToBuildingCamera();

        _building = Instantiate(building);

        while (true)
        {
            RaycastHit generalHit;
            Ray firtRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(firtRay, out generalHit, float.MaxValue, groundLayer))
            {
                var snapPos = grid.GetNearestPointOnGrid(generalHit.point);
                _building.transform.position = snapPos;
                if (Input.GetMouseButtonDown(0))
                {
                    if (_building.CheckCollisions())
                    {
                        _building.DoOperation();
                        GameManager.Instance.SwitchToPlayerFollowerCamera();
                        EventManager.OnPlayingGame();
                        break;
                    }
                }
            }
            yield return null;
        }
    }

    public void CallIEDragBuilding(BuildingBase building)
    {
        StartCoroutine(IEDragBuilding(building));
    }
}
