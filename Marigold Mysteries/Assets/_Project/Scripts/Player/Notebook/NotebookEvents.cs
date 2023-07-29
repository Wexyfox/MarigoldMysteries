using UnityEngine.Events;

namespace MarigoldMysteries
{
    public static class NotebookEvents
    {
        public static event UnityAction NotebookModeActivate;
        public static void InvokeNotebookModeActivate()
        {
            NotebookModeActivate?.Invoke();
        }

        public static event UnityAction NotebookModeDeactivate;
        public static void InvokeNotebookModeDeactivate()
        {
            NotebookModeDeactivate?.Invoke();
        }

        public static event UnityAction NotebookPageTurnLeftAttempt;
        public static void InvokeNotebookPageTurnLeftAttempt()
        {
            NotebookPageTurnLeftAttempt?.Invoke();
        }

        public static event UnityAction NotebookPageTurnRightAttempt;
        public static void InvokeNotebookPageTurnRightAttempt()
        {
            NotebookPageTurnRightAttempt?.Invoke();
        }
    }
}
