using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private PlayerHealth _playerHealth;

	[SerializeField] private Slider slider;
	[SerializeField] private Image fill;

    private void Awake()
    {
        _playerHealth.HealthChanged += SetHealth;

        SetMaxHealth(100);
    }

    private void OnDestroy()
    {
        _playerHealth.HealthChanged -= SetHealth;
    }

    public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;
	}

    public void SetHealth(float health)
	{
		slider.value = health;
	}
}