using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    [SerializeField] private int _triggerDamage;
    [SerializeField] private float _hitCooldown;

    private float _lastHitTime;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<PlayerController>() && _lastHitTime + _hitCooldown < Time.time)
        {
            _lastHitTime = Time.time;
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(_triggerDamage);
        }
    }
}
