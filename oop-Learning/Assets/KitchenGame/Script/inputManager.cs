using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace kitchen_Project
{
    public class inputManager : MonoBehaviour
    {

        public event EventHandler OnInteractAction;
        private Input_Manage playerinputactions;
        private void Awake()
        {
            playerinputactions = new Input_Manage();
            playerinputactions.Player.Enable();

            playerinputactions.Player.interact.performed += Interact_performed;    
        }

        private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnInteractAction?.Invoke(this, EventArgs.Empty); // checking kay OnInteractAction null na ho agar null hoa to ? say agy ni run kry ga
            
            // If there are any subscribers to the OnInteractAction event, invoke the event
            // 'this' refers to the current object raising the event
            // 'EventArgs.Empty' means no extra data is passed
            // if (OnInteractAction != null)
            // {
            //     OnInteractAction(this, EventArgs.Empty);
            // }
        }
       



        public Vector2 GetMovementVectorNormalize()
        {
            Vector2 inputVector = playerinputactions.Player.Move.ReadValue<Vector2>();
            inputVector = inputVector.normalized;
            return inputVector;
        }
    }
}
