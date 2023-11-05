using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private ManipulationInput _manipulationInput;
    [SerializeField] private InteractionWithObjects _interactionWithObjects;

    private InteractionItem _currentInteractionItem;

    void Start()
    {
        _interactionWithObjects.InteractionIsPossible += SetCurrentInteractionItem;
        _interactionWithObjects.InteractionIsNotPossible += ClearCurrentInteractionItem;

        _manipulationInput.InteractionKeyPressed += InteractWithObject;
    }

    private void OnDestroy()
    {

        _interactionWithObjects.InteractionIsPossible += SetCurrentInteractionItem;
        _interactionWithObjects.InteractionIsNotPossible += ClearCurrentInteractionItem;

        _manipulationInput.InteractionKeyPressed -= InteractWithObject;
    }

    private void SetCurrentInteractionItem(InteractionItem item)
    {
        _currentInteractionItem = item;
    }

    private void ClearCurrentInteractionItem()
    { 
        _currentInteractionItem = null;
    }

    private void InteractWithObject()
    {
        if( _currentInteractionItem != null )
        {
            _currentInteractionItem.Iteract();
        }
    }
}