using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        Vector2 direction = MyMath.DegreeToVector2(transform.eulerAngles.z);
        direction.Normalize();
        transform.position += new Vector3(direction.x, direction.y, 0f) * speed * Time.deltaTime;
    }
}
