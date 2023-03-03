using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _bulletForce = 20f;
    [SerializeField] private float _detectRadius;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _shootCooldown;

    private Transform _enemy;
    private float _lastShoot;

    private void Update()
    {
        ChooseEnemy();

        if (_enemy != null)
        {
            if(_lastShoot + _shootCooldown < Time.time)
            {
                _lastShoot = Time.time;
                Shoot();
            }
            Aim();
        }
    }

    private void ChooseEnemy()
    {
        var detectedObjects = Physics2D.OverlapCircleAll(transform.position, _detectRadius, _enemyLayer);
        float minRange = Mathf.Infinity;
        Transform choosedEnemy = null;

        if (detectedObjects != null)
        {
            foreach (Collider2D enemy in detectedObjects)
            {
                float currentRange = Vector3.Distance(transform.position, enemy.transform.position);
                if (minRange >= currentRange)
                {
                    minRange = currentRange;
                    choosedEnemy = enemy.transform;
                }
            }
        }

        if (choosedEnemy != null)
        {
            _enemy = choosedEnemy;
        }
    }

    private void Aim()
    {
        Vector2 firePointPosition = new Vector2(_firePoint.position.x, _firePoint.position.y);
        Vector2 enemyDirection = new Vector2(_enemy.position.x, _enemy.position.y);
        Vector2 lookDirection = enemyDirection - firePointPosition;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        Vector3 newAngles = _firePoint.eulerAngles;
        newAngles.z = angle;
        _firePoint.eulerAngles = newAngles;
    }

    private void Shoot()
    {
        GameObject _bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        Rigidbody2D _rigidbody = _bullet.GetComponent<Rigidbody2D>();
        _rigidbody.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
    }
}
