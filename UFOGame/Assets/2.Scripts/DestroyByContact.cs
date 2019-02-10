using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public HealthBar healthBar;
    public int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            return;
        }

        if (collision.CompareTag("Bullet"))
        {
            GameController.Instance.Despawn(collision.gameObject);
        }

        healthBar.Decrease();

        if (healthBar.healthCur == 0)
        {
            if (this.gameObject.CompareTag("Player"))
            {
                GameController.Instance.Gameover();
            }
            else if (this.gameObject.CompareTag("Enemy"))
            {
                GameController.Instance.AddScore(score);
            }
            Instantiate(explosion, transform.position, transform.rotation);
            SoundManager.Instance.PlaySFX("explosion");
            GameController.Instance.Despawn(this.gameObject);
        }
    }
}
