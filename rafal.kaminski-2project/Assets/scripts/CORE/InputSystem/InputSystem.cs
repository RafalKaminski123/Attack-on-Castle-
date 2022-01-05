using UnityEngine;

namespace SDA.Core
{
    public class InputSystem : MonoBehaviour
    {
        private bool isEnabled = false;
        private float horizontalValue = 0f;
        private float verticalValue = 0f;
        private bool isActionClicked = false;

        private bool isJumpDown;
        private bool isJump = false;
        private bool isJumpUp;

        public bool IsJumpClicked()
        {
            return isJumpDown;
        }

        public bool IsActionClicked()
        {
            return isActionClicked;
        }

        public float GetHorizontalInput()
        {
            return horizontalValue;
        }

        public float GetVerticalInput()
        {
            return verticalValue;
        }

        public void EnableInput()
        {
            isEnabled = true;
        }

        public void DisableInput()
        {
            isEnabled = false;
            horizontalValue = 0f;
            verticalValue = 0f;
            isJumpDown = false;
            isJump = false;
            isJumpUp = false;
            isActionClicked = false;
        }

        public void UpdateInput()
        {
            if (!isEnabled) //if(isEnabled == false)
            {
                return;
            }

            isJumpUp = false;
            horizontalValue = Input.GetAxis("Horizontal");
            verticalValue = Input.GetAxis("Vertical");
            isActionClicked = Input.GetAxisRaw("Action") > 0;

            bool isJumpClickedInCurrentFrame = Input.GetAxisRaw("Jump") > 0;
            if (!isJump && isJumpClickedInCurrentFrame)
            {
                isJumpDown = true;
                isJump = true;
            }
            else if (isJump && isJumpClickedInCurrentFrame)
            {
                isJumpDown = false;
                isJump = true;
            }
            else if (isJump && !isJumpClickedInCurrentFrame)
            {
                isJumpUp = true;
                isJump = false;
            }
        }
    }
}
