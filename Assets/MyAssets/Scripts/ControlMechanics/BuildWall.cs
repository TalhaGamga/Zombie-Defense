using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
public class BuildWall : MonoBehaviour
{
    [SerializeField] Grid grid;
    [SerializeField] GameObject wall;
    Coroutine buildCor;
    bool isAble = false;

    [SerializeField] NavMeshAgent navMesh;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isAble = true;
            buildCor = StartCoroutine(IEBuild());
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isAble = false;
            StopCoroutine(buildCor);
        }
    }

    IEnumerator IEBuild()
    {
        while (isAble)
        {
            Vector3 point = grid.GetNearestPointOnGrid(transform.position + Vector3.up * 2.5f - navMesh.velocity.normalized * 3);

            if (grid.replecables[point] == 0)
            {
                yield return null;
            }

            else
            {

                GameObject _wall = Instantiate(wall, point, Quaternion.identity);
                grid.replecables[point] = 0;
                float angle = GetAngle(navMesh.velocity, Vector3.forward);

                if (angle>=45 && angle <=90 || angle >=90 && angle <=135)
                {
                    _wall.transform.Rotate(0, 90, 0);
                }
            }

            yield return new WaitForSeconds(.1f);
        }
    }

    float GetAngle(Vector3 v1, Vector3 v2)
    {
        return Vector3.Angle(v1, v2);
    }
}