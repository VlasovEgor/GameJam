using UnityEngine;

public class PlatfromActivator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private GameObject _stone;

    private bool IsActive = false;

    private void OnTriggerEnter(Collider other)
    {
        SpawnStone();
    }

    private void SpawnStone()
    { 
        if(IsActive == true)
        {
            return;
        }

        Instantiate(_stone, _spawnPosition.position, Quaternion.identity);
        IsActive = true;
    }
}