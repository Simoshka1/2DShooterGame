using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _moveSpeed = 5.0f;

    private Rigidbody2D _rigidbody;
    private Vector2 _movement;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); 
    }
    private void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        _rigidbody.velocity = _movement * _moveSpeed * Time.fixedDeltaTime;
    }

    private void OnEnable()
    {
        _health.HealthChanged += _healthBar.UpdateHealthBar;
        _health.Killed += UIManager.Instance.ShowLoseScreen;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= _healthBar.UpdateHealthBar;
        _health.Killed -= UIManager.Instance.ShowLoseScreen;
    }
}