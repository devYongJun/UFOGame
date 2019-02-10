using System;
using UnityEngine;

[Serializable]
public struct Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float fireInterval;
    public Boundary boundary;
    public Transform bulletSpawn;

    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveDirection;
    private float _nextFire;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        _moveDirection = new Vector2(h, v);
        _moveDirection.Normalize();

        if (Input.GetButton("Fire1") && Time.time > _nextFire)
        {
            _nextFire = Time.time + fireInterval;
            PoolObject poolObj = GameController.Instance.playerBulletPool.Pop();
            poolObj.transform.position = bulletSpawn.position;
            poolObj.transform.rotation = bulletSpawn.rotation;
            SoundManager.Instance.PlaySFX("laser");
        }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = _moveDirection * speed * Time.fixedDeltaTime;

        Vector2 movePosition = new Vector2(
            Mathf.Clamp(_rigidbody2D.position.x + velocity.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(_rigidbody2D.position.y + velocity.y, boundary.yMin, boundary.yMax)
        );
        _rigidbody2D.MovePosition(movePosition);
    }
}
