using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    [SerializeField] private Transform _enemyTransform;
    [SerializeField] private Vector3 LeftEuler;
    [SerializeField] private Vector3 RightEuler;
    [SerializeField] private float RotationSpeed=2;

    private Vector3 _targetEuler;

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        _enemyTransform.localRotation = Quaternion.Lerp(_enemyTransform.localRotation, Quaternion.Euler(_targetEuler), Time.deltaTime * RotationSpeed);
    }

    public void RotateLeft()
    {
        _targetEuler = LeftEuler;
    }

    public void RotateRight()
    {
        _targetEuler = RightEuler;
    }

}
