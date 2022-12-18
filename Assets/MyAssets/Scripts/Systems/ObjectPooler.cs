using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObjectPooler : Singleton<ObjectPooler>
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools = new List<Pool>();
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    public Transform parent;

    Vector3 bagInitScale;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab, parent);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }

        bagInitScale = PlayerManager.Instance.bagObj.localScale;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, Transform collectPoint)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }


    public IEnumerator IECollectPrices(string tag, Vector3 position, Quaternion rotation, Transform collectPoint)
    {
        int num = Random.Range(10, 15);
        //bagObj.transform.DOScale(bagInitScale + Vector3.forward * 2 + Vector3.right, .1f * num).SetEase(Ease.InOutBounce).
        //    OnComplete(() => bagObj.transform.DOScale(bagInitScale, .1f * num)).SetEase(Ease.InOutBounce);

        List<ICollectable> collectables = new List<ICollectable>();
        for (int i = 0; i < num; i++)
        {
            Vector2 point = Random.insideUnitCircle;

            GameObject obj = SpawnFromPool(tag, position, rotation, collectPoint);
            obj.transform.position = new Vector3(position.x + point.x, 0, position.z + point.y);
            collectables.Add(obj.GetComponent<ICollectable>());
        }

        foreach (Collectable collectable in collectables)
        {
            collectable.Collect(collectPoint);
            yield return new WaitForSeconds(.1f);
        }

        collectables.Clear();
    }

    public void CallCollectPrices(string tag, Vector3 position, Quaternion rotation, Transform parent)
    {
        StartCoroutine(IECollectPrices(tag, position, rotation, parent));
    }

    public void DropGold(Vector3 pos, Transform collectPoint)
    {
        GameObject obj = SpawnFromPool(PriceType.Gold.ToString(), pos + Vector3.up*3, Quaternion.identity, collectPoint);
        obj.GetComponent<Collectable>().Collect(PlayerManager.Instance.collectPoint);
    }
}
