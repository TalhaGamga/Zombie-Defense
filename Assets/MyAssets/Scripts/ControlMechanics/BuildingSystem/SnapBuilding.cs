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

    BuildingBase _building;
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

        _building = Instantiate(building);

        while (true)
        { 
            RaycastHit generalHit;
            Ray firtRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(firtRay, out generalHit, float.MaxValue,groundLayer))
            {
                var snapPos = grid.GetNearestPointOnGrid(generalHit.point);
                _building.transform.position = snapPos;
                Debug.Log(_building.collisions.Count);
                if (Input.GetMouseButtonDown(0))
                {
                    if (Grid.replecables[snapPos] < 1)
                    {
                        if (_building.CheckCollisions())
                        {
                            Debug.Log(building.CheckCollisions());
                            _building.DoOperation();
                            
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
