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
            transform.position += moveDir * movespeed * Time.deltaTime;

            float rotSpeed = 10f;
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotSpeed);
        }
    }
}