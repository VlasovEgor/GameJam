using System;
using UnityEngine;

public class TriggerItem : MonoBehaviour
{
    public event Action<InteractionItem> InteractionIsPossible;
    public event Action InteractionIsNotPossible;

    [SerializeField] private InteractionItem _interactionObject;

    private void OnTriggerEnter(Collider other)
    {
        ChangeState(MarkStatus.Active);
    }
   
    private void OnTriggerExit(Collider other)
    {
        ChangeState(MarkStatus.NotActive);
    }

    private void ChangeState(MarkStatus markStatus)
    {
        if (markStatus == MarkStatus.Active)
        {
            InteractionIsPossible?.Invoke(_interactionObject);
        }
        else
        {
            InteractionIsNotPossible?.Invoke();
        }
    }
}

public enum MarkStatus
{
    NotActive = 0,
    Active = 1
}