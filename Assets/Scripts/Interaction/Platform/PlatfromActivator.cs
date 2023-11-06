using UnityEngine;

public class PlatfromActivator : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private GameObject _stone;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Scales scales;

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

        _audioSource.Play();
        Instantiate(_stone, _spawnPosition.position, Quaternion.identity);
        IsActive = true;

        scales.ChangeState();
    }
}