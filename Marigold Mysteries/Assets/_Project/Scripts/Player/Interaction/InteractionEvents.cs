using UnityEngine.Events;

namespace MarigoldMysteries
{
    public static class InteractionEvents
    {
        public static event UnityAction<string[]> StartedConversation;
        public static void InvokeStartedConversation(string[] pa_NpcNames)
        {
            StartedConversation?.Invoke(pa_NpcNames);
        }

        public static event UnityAction FinishedConversation;
        public static void InvokeFinishedConversation()
        {
            FinishedConversation?.Invoke();
        }

        public static event UnityAction<string[]> StartedInpecting;
        public static void InvokeStartedInpecting(string[] pa_ItemNames)
        {
            StartedInpecting?.Invoke(pa_ItemNames);
        }

        public static event UnityAction FinishedInspecting;
        public static void InvokeFinishedInspecting()
        {
            FinishedInspecting?.Invoke();
        }
    }
}
