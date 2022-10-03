using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoor : MonoBehaviour
{
    // Start is called before the first frame update

    Transform[] objs;
    void Start()
    {
        objs = GetComponentsInChildren<Transform>();
        Debug.Log(objs.Length);

    }

    // Update is called once per frame 
    void Update()
    {

    }


    public IEnumerator IEActivateDoor()
    {
        Debug.Log("çlýþtý");
        for (int i = 1; i < objs.Length; i++)
        {
            objs[i].gameObject.GetComponent<MeshRenderer>().enabled = true;
            yield return new WaitForSeconds(0.15f);
        }
    }
}
