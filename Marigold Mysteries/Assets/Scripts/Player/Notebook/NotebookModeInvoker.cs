using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MarigoldMysteries
{
    public class NotebookModeInvoker : MonoBehaviour
    {
        [Header("Action Map")]
        [SerializeField] private PlayerInputActionMap am_PlayerInputActionMap;

        [Header("Dependent Scripts")]
        [SerializeField] private PlayerState s_PlayerState;

        private void OnEnable()
        {
            am_PlayerInputActionMap.Triggers.NotebookModeToggle.performed += NotebookModeToggle;
            am_PlayerInputActionMap.Triggers.NotebookModeToggle.Enable();
        }

        private void OnDisable()
        {
            am_PlayerInputActionMap.Triggers.NotebookModeToggle.performed -= NotebookModeToggle;
            am_PlayerInputActionMap.Triggers.NotebookModeToggle.Disable();
        }

        private void NotebookModeToggle(InputAction.CallbackContext pa_Callback)
        {
            bool l_Idle = s_PlayerState.CurrentStatus() == InputStateEnum.IDLE;
            bool l_Notebook = s_PlayerState.CurrentStatus() == InputStateEnum.NOTEBOOK;

            if (!(l_Idle || l_Notebook))
            {
                return;
            }

            if (l_Notebook)
            {
                NotebookEvents.InvokeNotebookModeDeactivate();
                return;
            }
            NotebookEvents.InvokeNotebookModeActivate();
        }
    }
}
