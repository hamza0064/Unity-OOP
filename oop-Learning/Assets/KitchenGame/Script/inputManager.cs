using UnityEngine;
using UnityEngine.InputSystem;
public class inputManager : MonoBehaviour
{

    private Input_Manage playerinputactions;
    private void Awake()
    {
        playerinputactions = new Input_Manage();
        playerinputactions.Player.Enable();
    }

    public Vector2 GetMovementVectorNormalize()
    {
        Vector2 inputVector = playerinputactions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        return inputVector;
    }
}
