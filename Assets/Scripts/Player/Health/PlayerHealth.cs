using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{   
    public event Action<float> HealthChanged;

    [SerializeField] private float _health;
 
    public void TakeDamage(float _damage)
    {    
        _health -= _damage;

        HealthChanged?.Invoke(_health);

        if (_health <= 0f)
        {
            Death();
        }
    }

    private void Death(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}