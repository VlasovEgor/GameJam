using UnityEngine;

public class Artifact : InteractionItem
{
    [SerializeField] private GameObject _stone;
    public override void Iteract()
    {
        Activate();
    }

    private void Activate()
    {
        Debug.Log("�� �������� ������");
        _stone.SetActive(false);
    }
   
}
