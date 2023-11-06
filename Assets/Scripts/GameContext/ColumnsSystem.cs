using UnityEngine;

public class ColumnsSystem : MonoBehaviour
{
    private ColumnSigns[] _signs;
    private int _numberCorrectlyPlacedColumns;


    [SerializeField] private GameObject _oldGrid;
    [SerializeField] private GameObject _newGrid;

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

            _oldGrid.SetActive(false);
            _newGrid.SetActive(false);


        }
        else
        {
            _numberCorrectlyPlacedColumns = 0;
        }
    }
}