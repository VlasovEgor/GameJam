using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    public float DamageValue = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            other.GetComponent<PlayerHealth>().TakeDamage(DamageValue);
        }
    }
}
