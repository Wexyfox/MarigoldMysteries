using UnityEngine;
using UnityEngine.InputSystem;

namespace MarigoldMysteries
{
    public class NotebookPageTurn : MonoBehaviour
    {
        [Header("Action Map")]
        [SerializeField] private PlayerInputActionMap am_PlayerInputActionMap;

        [Header("Dependent Scripts")]
        [SerializeField] private PlayerState s_PlayerState;

        private void OnEnable()
        {
            am_PlayerInputActionMap.Notebook.LeftPageTurn.performed += LeftPageTurn;
            am_PlayerInputActionMap.Notebook.RightPageTurn.performed += RightPageTurn;
            am_PlayerInputActionMap.Notebook.Enable();
        }

        private void OnDisable()
        {
            am_PlayerInputActionMap.Notebook.LeftPageTurn.performed -= LeftPageTurn;
            am_PlayerInputActionMap.Notebook.RightPageTurn.performed -= RightPageTurn;
            am_PlayerInputActionMap.Notebook.Disable();
        }

        private void LeftPageTurn(InputAction.CallbackContext pa_Callback)
        {
            if (s_PlayerState.CurrentStatus() != InputStateEnum.NOTEBOOK) return;
            NotebookEvents.InvokeNotebookPageTurnLeftAttempt();
        }

        private void RightPageTurn(InputAction.CallbackContext pa_Callback)
        {
            if (s_PlayerState.CurrentStatus() != InputStateEnum.NOTEBOOK) return;
            NotebookEvents.InvokeNotebookPageTurnRightAttempt();
        }
    }
}
