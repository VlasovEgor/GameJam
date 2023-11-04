using System;
using UnityEngine;

public class TriggerItem : MonoBehaviour
{
    public event Action<InteractionItem> InteractionIsPossible;
    public event Action InteractionIsNotPossible;

    [SerializeField] private InteractionItem _interactionObject;
   // [Space]
   // [SerializeField] private Transform _markTransform;
   // [Space]
   // [SerializeField] private float distance_active;
   // [SerializeField] private float angle_active;

    //private Transform _playerTransform;


   // private void Start()
   // {
   //     _playerTransform = FindObjectOfType<Player>().GetComponent<Transform>();
   // }


    private void OnTriggerEnter(Collider other)
    {
        ChangeState(MarkStatus.Active);
    }
   
    private void OnTriggerExit(Collider other)
    {
        ChangeState(MarkStatus.NotActive);
    }


    // private void LateUpdate()
    // {
    //     float distanse = Vector3.Distance(_playerTransform.position, _markTransform.position);                        
    //     float angle_to_object = Mathf.Abs(Vector3.SignedAngle(_markTransform.position - _playerTransform.position, _playerTransform.forward, Vector3.right));
    //
    //     if (distanse < distance_active && angle_to_object <= angle_active)
    //     {
    //         ChangeState(MarkStatus.Active);
    //     }
    //     else
    //     {
    //         ChangeState(MarkStatus.NotActive);
    //     }
    // }

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
