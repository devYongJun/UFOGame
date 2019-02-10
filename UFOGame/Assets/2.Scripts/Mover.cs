using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
