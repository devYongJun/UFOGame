using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public PoolObject prefab;
    public List<PoolObject> pools = new List<PoolObject>();

    public void Push(PoolObject bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.position = Vector3.zero;
        bullet.transform.rotation = Quaternion.identity;
        pools.Add(bullet);
    }

    public PoolObject Pop()
    { 
        if(pools.Count > 0)
        {
            int lastIndex = pools.Count - 1;
            PoolObject poolObj = pools[lastIndex];
            poolObj.gameObject.SetActive(true);
            pools.RemoveAt(lastIndex);
            return poolObj;
        }
        return CreateNew();
    }

    PoolObject CreateNew()
    {
        PoolObject poolObj = Instantiate<PoolObject>(prefab);
        poolObj.PushToPoolEvent += Push;
        return poolObj;
    }
}
