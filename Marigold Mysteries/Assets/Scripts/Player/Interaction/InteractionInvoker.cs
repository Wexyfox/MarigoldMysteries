using UnityEngine;
using UnityEngine.InputSystem;

namespace MarigoldMysteries
{
    public class InteractionInvoker : MonoBehaviour
    {
        [Header("Action Maps")]
        [SerializeField] private PlayerInputActionMap am_PlayerInputActionMap;

        [Header("Dependent Scripts")]
        [SerializeField] private PlayerState s_PlayerState;

        [SerializeField] private InteractionListener s_InteractionListener;

        private void OnEnable()
        {
            am_PlayerInputActionMap.Triggers.InteractionAttempt.performed += InteractionAttempt;
            am_PlayerInputActionMap.Triggers.InteractionAttempt.Enable();
        }

        private void OnDisable()
        {
            am_PlayerInputActionMap.Triggers.InteractionAttempt.performed -= InteractionAttempt;
            am_PlayerInputActionMap.Triggers.InteractionAttempt.Enable();
        }

        private void OnTriggerEnter2D(Collider2D pa_Collision)
        {
            if (!pa_Collision.GetComponent<InteractionListener>()) return;
            s_InteractionListener = pa_Collision.GetComponent<InteractionListener>();
        }

        private void OnTriggerExit2D(Collider2D pa_Collision)
        {
            if (pa_Collision.GetComponent<InteractionListener>() != s_InteractionListener) return;
            s_InteractionListener = null;
        }

        private void InteractionAttempt(InputAction.CallbackContext pa_Callback)
        {
            bool l_Idle = s_PlayerState.CurrentStatus() == InputStateEnum.IDLE;

            if (!l_Idle)
            {
                return;
            }

            if (s_InteractionListener == null)
            {
                return;
            }

            s_InteractionListener.Interact();
        }
    }
}
