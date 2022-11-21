using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] float interval = 5f;
    [SerializeField] float num = 130;

    public static Dictionary<Vector3, int> replecables;
    private void Awake()
    {
        replecables = new Dictionary<Vector3, int>();
    } 
    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        for (float x = 0; x < num; x += interval)
        {
            for (float z = 0; z < num; z += interval)
            {
                var point = GetNearestPointOnGrid(new Vector3(transform.position.x + x, 0f, transform.position.z + z));
                //replecables.Add(point, 0);
                Gizmos.DrawSphere(point, 0.5f);
            }
        }
    }

    private void Start()
    {
        for (float x = 0; x < num; x += interval)
        {
            for (float z = 0; z < num; z += interval)
            {
                var point = GetNearestPointOnGrid(new Vector3(transform.position.x + x, 0f, transform.position.z + z));
                replecables.Add(point, 0);
            }
        }
    }

    public Vector3 GetNearestPointOnGrid(Vector3 clickledPos)
    {
        clickledPos -= transform.position;

        int xCount = Mathf.RoundToInt(clickledPos.x / interval);
        int yCount = Mathf.RoundToInt(clickledPos.y / interval);
        int zCount = Mathf.RoundToInt(clickledPos.z / interval);

        Vector3 result = new Vector3(
            (float)xCount * interval, 0, (float)zCount * interval);

        result += transform.position;

        return result;
    }

}


