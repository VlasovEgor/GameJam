using UnityEngine;

public class ColumnSigns : MonoBehaviour
{
    [SerializeField] private RotateColumn _rotateColumn;

    [SerializeField] private Signs[] _signs;
    [Space]
    [SerializeField] private Signs _currnetSign;
    [SerializeField] private Signs _victorySign;

    private int _currentIndex;

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
        }
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

