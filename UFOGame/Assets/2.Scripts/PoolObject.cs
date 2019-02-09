using UnityEngine;
using System.Collections;

public class PoolObject : MonoBehaviour
{
    public delegate void PushToPool(PoolObject obj);

    public event PushToPool PushToPoolEvent;

    public void Die()
    {
        PushToPoolEvent(this);
    }
}
