using System;
using UnityEngine;

public class InteractionWithObjects : MonoBehaviour
{
    public event Action<InteractionItem> InteractionIsPossible;
    public event Action InteractionIsNotPossible;

    [SerializeField] private float _interactionDistance;
    [SerializeField] private Transform _camera;

    void Update()
    {
        if (Physics.Raycast(transform.position, _camera.forward, out var hit, _interactionDistance))
        {
            var obj = hit.collider.gameObject;
            

            if(obj.GetComponent<TriggerItem>() == true)
            {
                var item = obj.GetComponent<TriggerItem>().GetInteractionItem();
                Debug.Log(item);
                InteractionIsPossible?.Invoke(item);
            }
            
        }
        else
        {
            InteractionIsNotPossible?.Invoke();
        }
    }
}
