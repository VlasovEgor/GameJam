using UnityEngine;

public class Artifact : InteractionItem
{
    [SerializeField] private GameObject _artifact;
    [SerializeField] protected PlayerTeleport _playerTeleport;

    public override void Iteract()
    {
        Activate();
    }

    private void Activate()
    {
        Debug.Log("�� �������� ������");
        _playerTeleport.SetActiveTrue();
        _artifact.SetActive(false);
    }
   
}