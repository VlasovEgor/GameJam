using UnityEngine;

public class ColumnsSystem : MonoBehaviour
{
    private ColumnSigns[] _signs;
    private int _numberCorrectlyPlacedColumns;

    private void OnEnable()
    {
        _signs = FindObjectsOfType<ColumnSigns>();

        foreach (ColumnSigns sign in _signs)
        {
            sign.ColumnPositionedCorrectly += CheckingPositionAllColums;
        }
    }

    private void OnDisable()
    {
        foreach (ColumnSigns sign in _signs)
        {
            sign.ColumnPositionedCorrectly -= CheckingPositionAllColums;
        }
    }

    private void CheckingPositionAllColums()
    {
        foreach (ColumnSigns sign in _signs)
        {
            if (sign.CheckWhetherColumnIsStandingCorrectly() == true)
            {
                _numberCorrectlyPlacedColumns++;
            }
        }

        Debug.Log(_numberCorrectlyPlacedColumns);

        CheckVictory();
    }

    private void CheckVictory()
    {
        if(_numberCorrectlyPlacedColumns ==  _signs.Length)
        {
            Debug.Log("рш онаедхк, лнкндеж, цнпфсяэ");
        }
        else
        {
            _numberCorrectlyPlacedColumns = 0;
        }
    }
}