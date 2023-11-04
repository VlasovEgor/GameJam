using UnityEngine;

public class ActivateColumn : MonoBehaviour
{   
    public bool ColumnIsActive
    {
        get { return _isActive; }
    }

    [SerializeField] private bool _isActive = false;

    public bool GetColumnCondition()
    {
        return _isActive;
    }

    public void SetColumnActive()
    {   
        if (_isActive == true)
        {
            Debug.Log("������� ��� �������");
            return;
        }

        _isActive = true;
        Debug.Log("������� ������������");
    }
}