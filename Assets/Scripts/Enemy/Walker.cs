using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Walker : MonoBehaviour
{
    [SerializeField] private Transform _enemyTransform;
    [Space]
    [SerializeField] private Transform _leftTarget;
    [SerializeField] private Transform _rightTarget;
    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private float _stopTime;
    [Space]
    [SerializeField] private Direction _currentDirection;
    [Space]
    [SerializeField] private UnityEvent _eventOnLeftTarget;
    [SerializeField] private UnityEvent _eventOnRightTarget;

    private void Start()
    {
        _leftTarget.parent = null;
        _rightTarget.parent = null;

        StartCoroutine(Walk());
    }

    private IEnumerator Walk()
    {
        while (true)
        {
            if (_currentDirection == Direction.Left)
            {
                _enemyTransform.position -= new Vector3(Time.deltaTime * _speed, 0, 0);
                if (_enemyTransform.position.x < _leftTarget.position.x)
                {
                    _currentDirection = Direction.Right;
                    yield return new WaitForSeconds(_stopTime);
                    _eventOnLeftTarget.Invoke();
                }
            }
            else
            {
                _enemyTransform.position += new Vector3(Time.deltaTime * _speed, 0, 0);
                if (_enemyTransform.position.x > _rightTarget.position.x)
                {
                    _currentDirection = Direction.Left;
                    yield return new WaitForSeconds(_stopTime);
                    _eventOnRightTarget.Invoke();
                }
            }

            yield return null;
        }
    }
}


public enum Direction
{
    Left,
    Right
}