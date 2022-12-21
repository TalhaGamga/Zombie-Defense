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
            if (!isAble)
            {

                isAble = true;
                buildCor = StartCoroutine(IEBuild());
                return;
            }

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
                if (PlayerManager.Instance.priceDict[PriceType.Stone].currentPrice > 0)
                {

                    GameObject _wall = Instantiate(wall, point, Quaternion.identity);
                    grid.replecables[point] = 0;

                    PlayerManager.Instance.priceDict[PriceType.Stone].SetPrice(-1);
                }

            }

            yield return new WaitForSeconds(.1f);
        }
    }

    public void Build()
    {
        if (!isAble)
        {

            isAble = true;
            buildCor = StartCoroutine(IEBuild());
            return;
        }

        isAble = false;
        StopCoroutine(buildCor);
    }
}