using System;
using System.Threading.Tasks;
using UnityEngine;

public class TriggerItem : MonoBehaviour
{
    public event Action<InteractionItem> InteractionIsPossible;
    public event Action InteractionIsNotPossible;

    [SerializeField] private InteractionItem _interactionObject;

    public InteractionItem GetInteractionItem()
    {
        return _interactionObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        ChangeState(ItemStatus.Active);
    }

    private void OnTriggerExit(Collider other)
    {
        ChangeState(ItemStatus.NotActive);
    }

    private void ChangeState(ItemStatus markStatus)
    {
        if (markStatus == ItemStatus.Active)
        {
            InteractionIsPossible?.Invoke(_interactionObject);
        }
        else
        {
            InteractionIsNotPossible?.Invoke();
        }
    }
}

public enum ItemStatus
{
    NotActive = 0,
    Active = 1
}