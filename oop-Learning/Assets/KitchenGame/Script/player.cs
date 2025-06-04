using System;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

namespace kitchen_Project
{
    public class player : MonoBehaviour
    {
        

        public static player Instance { get; private set; }
        public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
        public class OnSelectedCounterChangedEventArgs : EventArgs
        {
            public clearcounter selectedCounter;
        }
        [SerializeField] private float movespeed = 7f;
        [SerializeField] private inputManager inputmanager;

        [SerializeField] private LayerMask CounterLayerMask;

        [SerializeField] private clearcounter selectedCouter;

        private Vector3 lastinteraction;

        private void Awake()
        {
            if (Instance == null)
            {
                Debug.Log("Yha or biii player kay instance hy ");
            }
            Instance = this;
        }
        private void Start()
        {
            inputmanager.OnInteractAction += Inputmanager_OnInteractAction;
        }
        private void Inputmanager_OnInteractAction(object sender, System.EventArgs e)
        {
            if (selectedCouter != null)
            {
                selectedCouter.Interact();
            }
        }
        private void Update()
        {
            HandleMovement();
            HandleInteractions();
        }

        private void HandleInteractions()
        {
            Vector2 inputVector = inputmanager.GetMovementVectorNormalize();
            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

            if (moveDir != Vector3.zero)
            {
                lastinteraction = moveDir;
            }

            float interactionDistance = 2f;
            if (Physics.Raycast(transform.position, lastinteraction, out RaycastHit raycastHit, interactionDistance, CounterLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out clearcounter clearcounters))
                {
                    // clearcounters.Interact();
                    if (clearcounters != selectedCouter)
                    {
                        SetSelectCounter(clearcounters);
                    }

                }
                else
                {
                   SetSelectCounter(null);
                }

            }
            else
            {
                selectedCouter = null;
                SetSelectCounter(null);
            }


            // Debug.Log(selectedCouter);
        }
        private void HandleMovement()
        {

            Vector2 inputVector = inputmanager.GetMovementVectorNormalize();
            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

            float moveDistance = movespeed * Time.deltaTime;
            float playerRadius = 0.7f;
            float playerHeight = 2f;
            bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);


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

        private void SetSelectCounter(clearcounter selectedCounter)
        {
            this.selectedCouter = selectedCounter;
            OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
            {
                selectedCounter = selectedCouter
            });

        }
    }
}