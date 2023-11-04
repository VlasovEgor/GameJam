using System;
using System.Collections;
using UnityEngine;

public class RotateColumn : MonoBehaviour
{
    public event Action ColumnTurned;

    [SerializeField] private GameObject _column;
    [SerializeField] private ActivateColumn _activateColumn;
    [Space]
    [SerializeField] private float _speedRotation;

    private float _angleRotation = 90;
    private Quaternion _targetRotation;

    public void ActivateRotate()
    {
        if (_activateColumn.GetColumnCondition() == false)
        {
            Debug.Log("Колонна ещё не активирована");
            return;
        }

        Debug.Log("ВЖУХ");

        _targetRotation = _column.transform.rotation * Quaternion.Euler(0, _angleRotation, 0);
        StartCoroutine(RotateObject());
       
    }


    private IEnumerator RotateObject()
    {
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
    }
}