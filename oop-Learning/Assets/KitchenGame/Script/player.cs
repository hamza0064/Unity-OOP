using UnityEngine;
using UnityEngine.InputSystem;

namespace kitchen_Project
{
    public class player : MonoBehaviour
    {
        [SerializeField] private float movespeed = 7f;
        [SerializeField] private inputManager inputmanager;
        private void Update()
        {
            Vector2 inputVector = inputmanager.GetMovementVectorNormalize();

            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

            float moveDistance = movespeed * Time.deltaTime;
            float playerRadius = 0.7f;
            float playerHeight = 2f;
            bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir , moveDistance);

            // // Draw capsule direction as a line (just for visualization)
            // Color rayColor = canMove ? Color.green : Color.red;
            // Vector3 rayStart = transform.position + Vector3.up * (playerHeight / 2);
            // Vector3 rayEnd = rayStart + moveDir.normalized * moveDistance;

            // // Scene view: Draw the full movement direction
            // Debug.DrawLine(rayStart, rayEnd, rayColor, 0.3f);

            // Debug.Log(canMove);
            if (!canMove)
            {
                Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

                if (canMove)
                {
                    moveDir = moveDirX;
                }
                else
                {
                    Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                    canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                    if (canMove)
                    {
                        moveDir = moveDirZ;
                    }
                    else
                    {
                        
                    }
                }
            }

            if (canMove)
            {
                transform.position += moveDir * movespeed * Time.deltaTime;
            }

            float rotSpeed = 10f;
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotSpeed);
        }
    }
}