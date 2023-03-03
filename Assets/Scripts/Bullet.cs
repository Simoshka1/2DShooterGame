using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _bulletDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(_bulletDamage);
        }
        if (!collision.gameObject.GetComponent<PlayerController>())
            Destroy(gameObject);
    }
}
