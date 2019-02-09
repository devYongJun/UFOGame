using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class EnemyBase : MonoBehaviour
{
    public float fireInterval;
    public GameObject bullet;
    public Transform bulletSpawn;

    private void OnEnable()
    {
        StartCoroutine(CoFire());
    }

    private IEnumerator CoFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireInterval);

            Fire();
        }
    }

    protected abstract void Fire();
}
