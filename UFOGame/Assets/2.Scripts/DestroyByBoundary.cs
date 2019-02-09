using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.Instance.Despawn(collision.gameObject);
    }
}
