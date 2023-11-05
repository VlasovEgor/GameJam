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
        Debug.Log("рш онднапюк йюлемэ");
        _stone.SetActive(false);
    }
   
}
