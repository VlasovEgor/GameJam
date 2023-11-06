using System.Collections;
using UnityEngine;

public class LeverActivator : InteractionItem
{
    [SerializeField] private GameObject _lever;
    [SerializeField] private ActivateColumn _activateColumn;
    [SerializeField] private Door _door;
    [Space]
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _angleRotation = -35;

    [SerializeField] private AudioSource _audioSource;

    private Quaternion _targetRotation;
    private bool _isActive = false;

    public override void Iteract()
    {
        ActivateLever();
    }

    public void ActivateLever()
    {
        if (_isActive == true)
        {
            return;
        }

        _audioSource.Play();
        _targetRotation =  Quaternion.Euler(_angleRotation, 0, 0);
        StartCoroutine(RotateObject());

        _isActive = true;
    }


    private IEnumerator RotateObject()
    {

        Quaternion startRotation = _lever.transform.rotation;

        float startTime = Time.time;
        float endTime = startTime + _speedRotation;

        while (Time.time < endTime)
        {
            float progress = (Time.time - startTime) / _speedRotation;

            _lever.transform.rotation = Quaternion.Lerp(startRotation, _targetRotation, progress);

            yield return null;
        }

        _lever.transform.rotation = _targetRotation;

        _activateColumn.SetColumnActive();
        _door.Open();
    }
}
