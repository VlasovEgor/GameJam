using System;
using System.Collections;
using UnityEngine;

public class RotateColumn : InteractionItem
{
    public event Action ColumnTurned;

    [SerializeField] private GameObject _column;
    [SerializeField] private ActivateColumn _activateColumn;
    [Space]
    [SerializeField] private float _speedRotation;
    [SerializeField] private AudioSource _audioSource;

    private float _angleRotation = 90;
    private Quaternion _targetRotation;

    private bool _isRotating = false;

    public override void Iteract()
    {
        ActivateRotate();
    }

    public void ActivateRotate()
    {
        if (_activateColumn.GetColumnCondition() == false)
        {
            Debug.Log("������� ��� �� ������������");
            return;
        }
        if (_isRotating == true)
        {
            Debug.Log("������� ��� ���������");
            return;
        }

        Debug.Log("����");

        _targetRotation = _column.transform.rotation * Quaternion.Euler(0, _angleRotation, 0);
        _audioSource.Play();
        StartCoroutine(RotateObject());
       
    }


    private IEnumerator RotateObject()
    {
        _isRotating = true;

        Quaternion startRotation = _column.transform.rotation;

        float startTime = Time.time;
        float endTime = startTime + _speedRotation;

        while (Time.time < endTime)
        {
            float progress = (Time.time - startTime) / _speedRotation;

            _column.transform.rotation = Quaternion.Lerp(startRotation, _targetRotation, progress);

            yield return null;
        }

        _column.transform.rotation = _targetRotation;
        ColumnTurned?.Invoke();
        _isRotating = false;
    }
}