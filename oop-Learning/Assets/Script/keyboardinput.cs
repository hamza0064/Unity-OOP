using UnityEngine;
using UnityEngine.InputSystem;


namespace learning_data
{
    public class keyboardinput : MonoBehaviour
    {
        void Update()
        {
            if (Keyboard.current.rightArrowKey.isPressed)
            {
                virualinputManager.Instance.MoveRight = true;
            }
            else
            {
                virualinputManager.Instance.MoveRight = false;
            }

            if (Keyboard.current.leftArrowKey.isPressed)
            {
                virualinputManager.Instance.MoveLeft = true;
            }
            else
            {
                virualinputManager.Instance.MoveLeft = false;
            }

        }
    }
}
