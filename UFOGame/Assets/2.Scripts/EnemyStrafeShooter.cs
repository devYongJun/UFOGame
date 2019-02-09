using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrafeShooter : EnemyBase
{
    public int bulletCount;
    public float angleStart;
    public float angleBetween;
    public float strafeInterval;

    protected override void Fire()
    {
        StartCoroutine(CoStrafe());
    }

    private IEnumerator CoStrafe()
    {
        float angle = angleStart;

        for (int i = 0; i < bulletCount; i++)
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
            PoolObject poolObj = GameController.Instance.enemyBulletPool.Pop();
            poolObj.transform.position = bulletSpawn.position;
            poolObj.transform.rotation = rotation;

            yield return new WaitForSeconds(strafeInterval);

            angle += angleBetween;
        }
    }
}
