using UnityEngine;
using UnityEngine.InputSystem;

namespace MarigoldMysteries
{
    public class MovementInvoker : MonoBehaviour
    {
        [Header("Action Map")]
        [SerializeField] private PlayerInputActionMap am_PlayerInputActionMap;

        [Header("Dependent Scripts")]
        [SerializeField] private PlayerState s_PlayerState;

        private Vector2 pr_MovementVector;

        private void OnEnable()
        {
            am_PlayerInputActionMap.Movement.Move.performed += MovementInputChanged;
            am_PlayerInputActionMap.Movement.Move.canceled += MovementInputChanged;
            am_PlayerInputActionMap.Movement.Move.Enable();
        }

        private void OnDisable()
        {
            am_PlayerInputActionMap.Movement.Move.performed -= MovementInputChanged;
            am_PlayerInputActionMap.Movement.Move.canceled -= MovementInputChanged;
            am_PlayerInputActionMap.Movement.Move.Disable();
        }

        private void MovementInputChanged(InputAction.CallbackContext pa_Callback)
        {
            pr_MovementVector = pa_Callback.ReadValue<Vector2>();
            InvokeMovementEvents();
        }

        private void InvokeMovementEvents()
        {
            bool l_Idle = s_PlayerState.CurrentStatus() == InputStateEnum.IDLE;
            bool l_Moving = s_PlayerState.CurrentStatus() == InputStateEnum.MOVING;

            if (!(l_Idle || l_Moving))
            {
                return;
            }

            if (pr_MovementVector == Vector2.zero)
            {
                MovementEvents.InvokeIdle();
                return;
            }

            MovementEvents.InvokeMovement(pr_MovementVector);
        }
    }
}
