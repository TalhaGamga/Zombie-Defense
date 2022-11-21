using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBuilding : MonoBehaviour
{
    [SerializeField] private Grid grid;
    [SerializeField] private LayerMask groundLayer;

    public static Action<BuildingBase> OnReplaceBuilding;
      
    public BuildingBase building;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCoroutine(IEDragBuilding());
        }
    }
    IEnumerator IEDragBuilding()
    {
        GameManager.Instance.SwitchToBuildingCamera();

        building = Instantiate(building);

        while (true)
        { 
            RaycastHit generalHit;
            Ray firtRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(firtRay, out generalHit, float.MaxValue,groundLayer))
            {
                var snapPos = grid.GetNearestPointOnGrid(generalHit.point);
                building.transform.position = snapPos;
                if (Input.GetMouseButtonDown(0))
                { 
                    if (Grid.replecables[snapPos] != 1)
                    {
                        if (building.CheckCollisions())
                        {
                            building.DoOperation();

                            Grid.replecables[snapPos] = 1;
                            GameManager.Instance.SwitchToPlayerFollowerCamera();
                            break;
                        }
                    }
                }
            }
            yield return null;
        }
    }
}
