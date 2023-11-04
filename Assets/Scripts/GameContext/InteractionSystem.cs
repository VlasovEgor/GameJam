using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private ManipulationInput _manipulationInput;

    private InteractionItem _currentInteractionItem;
    private TriggerItem[] _marks;

    void Start()
    {
        _marks = FindObjectsOfType<TriggerItem>();

        foreach (var mark in _marks)
        {
            mark.InteractionIsPossible += SetCurrentInteractionItem;
            mark.InteractionIsNotPossible += ClearCurrentInteractionItem;
        }

        _manipulationInput.InteractionKeyPressed += InteractWithObject;
    }

    private void OnDestroy()
    {
        foreach (var mark in _marks)
        {
            mark.InteractionIsPossible -= SetCurrentInteractionItem;
            mark.InteractionIsNotPossible -= ClearCurrentInteractionItem;
        }

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
