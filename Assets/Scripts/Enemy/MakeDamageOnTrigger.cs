using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    public float DamageValue = 20;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Attack1");
        if (other.GetComponent<PlayerHealth>() == true)
        {
            Debug.Log("Attack2");
            other.GetComponent<PlayerHealth>().TakeDamage(DamageValue);
        }
    }
}
