using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private float _maxHealth = 100;

	[SerializeField] private Slider slider;
	[SerializeField] private Image fill;

    private void Awake()
    {
        _playerHealth.HealthChanged += SetHealth;

        SetMaxHealth(_maxHealth);
    }

    private void OnDestroy()
    {
        _playerHealth.HealthChanged -= SetHealth;
    }

    public void SetMaxHealth(float health)
	{
		slider.maxValue = health;
		slider.value = health;
	}

    public void SetHealth(float health)
	{
		slider.value = health;
	}
}