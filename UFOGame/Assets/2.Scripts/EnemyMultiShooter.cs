using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMultiShooter : EnemyBase
{
    public float[] bulletAngles;

    protected override void Fire()
    {
        for (int i = 0; i < bulletAngles.Length; i++)
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, bulletAngles[i]);
            PoolObject poolObj = GameController.Instance.enemyBulletPool.Pop();
            poolObj.transform.position = bulletSpawn.position;
            poolObj.transform.rotation = rotation;
        }
    }
}
