using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{   
    public event Action<float> HealthChanged;

    [SerializeField] private float _maxHealth;

    [SerializeField] private float _currentHealth;

    [SerializeField] private float _timeBeforeRegeneration;

    [SerializeField] private float _regenerationSpeed;

    private bool _isRegenerationEnabled = false;

    private void Update()
    {
        RegenerateHealth();
    }

    public void TakeDamage(float _damage)
    {    
        _currentHealth -= _damage;

        _isRegenerationEnabled = false;

        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0f)
        {
            Death();
        }

        Invoke("EnableRegeneration", _timeBeforeRegeneration);
    }

    private void Death(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RegenerateHealth()
    {
        if (_isRegenerationEnabled == true && _currentHealth < _maxHealth)
        {
            _currentHealth += _regenerationSpeed * Time.deltaTime;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            HealthChanged?.Invoke(_currentHealth);
        }
    }

    public void EnableRegeneration()
    {
        _isRegenerationEnabled = true;
    }

    public void DisableRegeneration()
    {
        _isRegenerationEnabled = false;
    }
}