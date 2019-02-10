using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public PoolObject prefab;
    public List<PoolObject> poolList = new List<PoolObject>();

    public void Push(PoolObject bullet)
    {
        bullet.gameObject.SetActive(false);
        poolList.Add(bullet);
    }

    public PoolObject Pop()
    { 
        if(poolList.Count > 0)
        {
            int lastIndex = poolList.Count - 1;
            PoolObject poolObj = poolList[lastIndex];
            poolObj.gameObject.SetActive(true);
            poolList.RemoveAt(lastIndex);
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
