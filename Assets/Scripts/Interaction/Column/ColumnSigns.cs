using System;
using UnityEngine;

public class ColumnSigns : MonoBehaviour
{
    public event Action ColumnPositionedCorrectly;

    [SerializeField] private RotateColumn _rotateColumn;

    [SerializeField] private Signs[] _signs;
    [Space]
    [SerializeField] private Signs _currnetSign;
    [SerializeField] private Signs _victorySign;

    private int _currentIndex;

    private bool _columnIsStandingCorrectly;

    private void OnEnable()
    {
        _currnetSign = _signs[_currentIndex];

        _rotateColumn.ColumnTurned += ChangeSign;
    }

    private void OnDisable()
    {
        _rotateColumn.ColumnTurned -= ChangeSign;
    }

    public void ChangeSign()
    {
        if(_currentIndex == _signs.Length-1)
        {
            _currentIndex = 0;
        }
        else
        {
            _currentIndex++;
        }

        _currnetSign = _signs[_currentIndex];

        if(_currnetSign == _victorySign)
        {
            Debug.Log("Правильное распложение");
            _columnIsStandingCorrectly = true;
            ColumnPositionedCorrectly?.Invoke();
            
        }
        else
        {
            _columnIsStandingCorrectly = false;
        }
    }
    public bool CheckWhetherColumnIsStandingCorrectly()
    {
        return _columnIsStandingCorrectly;
    }
}

public enum Signs
{
    Eagle,
    Cat,
    Dog,
    Alligator,
    Eye,
    Human
}

