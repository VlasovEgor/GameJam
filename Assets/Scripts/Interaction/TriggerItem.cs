using UnityEngine;

public class TriggerItem : MonoBehaviour
{
    [SerializeField] private InteractionItem _interactionObject;

    public InteractionItem GetInteractionItem()
    {
        return _interactionObject;
    }
}
