using System;
using UnityEngine;

public class ManipulationInput : MonoBehaviour
{
    public event Action InteractionKeyPressed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PressInteractionKey();
        }
    }

    private void PressInteractionKey()
    {
        InteractionKeyPressed?.Invoke();
    }
}