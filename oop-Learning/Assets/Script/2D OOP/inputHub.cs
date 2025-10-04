using UnityEngine;

public class inputHub : MonoBehaviour
{
    private Input_Manage playerinputactions;

    private void Awake()
    {
        playerinputactions = new Input_Manage();
        playerinputactions.Player.Enable();

    }

    private void Update()
    {
        GetMovementVectorNormalize();
    }


    private void GetMovementVectorNormalize()
    {
        Vector2 inputVector = playerinputactions.Player.Move.ReadValue<Vector2>();
        inputVector = inputVector.normalized;
        centeralHub.Instance.MoveInput = inputVector;
    }
}
