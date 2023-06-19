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
    }
}
