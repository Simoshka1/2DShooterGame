using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _detectRadius;
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private int _reward;
    [SerializeField] private Health _health;

    private Rigidbody2D _rigidpody;
    private Transform _player;
    private Vector2 _direction;

    private void Start()
    {
        _rigidpody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (_player == null)
        {
            var detectedObject = Physics2D.OverlapCircle(transform.position, _detectRadius, _playerLayer);

            if (detectedObject != null)
            {
                _player = detectedObject.transform;
            }
        }
        else
        {
            Move();
        }
    }

    private void FixedUpdate()
    {
        _rigidpody.velocity = _direction * _speed * Time.fixedDeltaTime;
    }

    private void Move()
    {
        var directionY = _player.position.y - transform.position.y;
        var directionX = _player.position.x - transform.position.x;
        _direction = new Vector2(directionX, directionY).normalized;
    }
    
    private void AddPoints()
    {
        Score.Instance.AddPoints(_reward);
    }


    private void OnEnable()
    {
        _health.Killed += AddPoints;
    }

    private void OnDisable()
    {
        _health.Killed -= AddPoints;
    }
}
