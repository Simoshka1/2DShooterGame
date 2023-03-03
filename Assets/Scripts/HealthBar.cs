using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image _healthBarImage;
    public Health _playerHealth;
    public void UpdateHealthBar()
    {
        _healthBarImage.fillAmount = Mathf.Clamp((float)_playerHealth.Value / (float)_playerHealth.MaxHealth, 0, 1f);
    }
}