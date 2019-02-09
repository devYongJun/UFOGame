using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySingleShooter : EnemyBase
{
    protected override void Fire()
    {
        PoolObject poolObj = GameController.Instance.enemyBulletPool.Pop();
        poolObj.transform.position = bulletSpawn.position;
        poolObj.transform.rotation = bulletSpawn.rotation;
    }
}
