using UnityEngine;

namespace MarigoldMysteries
{
    public class PlayerState : MonoBehaviour
    {
        #region Editor Fields
        [SerializeField] private InputStateEnum e_InputStateEnum = InputStateEnum.IDLE;
        #endregion

        #region Event Subscriptions
        private void OnEnable()
        {
            MovementEvents.Movement += Movement;
            MovementEvents.Idle += Idle;

            SpellcastingEvents.SpellcastingModeActivate += SpellcastingModeActivate;
            SpellcastingEvents.SpellcastingModeDeactivate += Idle;

            NotebookEvents.NotebookModeActivate += NotebookModeActivate;
            NotebookEvents.NotebookModeDeactivate += Idle;

            InteractionEvents.StartedConversation += StartedConversation;
            InteractionEvents.FinishedConversation += Idle;

            InteractionEvents.StartedInpecting += StartedInpecting;
            InteractionEvents.FinishedInspecting += Idle;
        }

        private void OnDisable()
        {
            MovementEvents.Movement -= Movement;
            MovementEvents.Idle -= Idle;

            SpellcastingEvents.SpellcastingModeActivate -= SpellcastingModeActivate;
            SpellcastingEvents.SpellcastingModeDeactivate -= Idle;

            NotebookEvents.NotebookModeActivate -= NotebookModeActivate;
            NotebookEvents.NotebookModeDeactivate -= Idle;

            InteractionEvents.StartedConversation -= StartedConversation;
            InteractionEvents.FinishedConversation -= Idle;

            InteractionEvents.StartedInpecting -= StartedInpecting;
            InteractionEvents.FinishedInspecting -= Idle;
        }
        #endregion

        private void Movement(Vector2 pa_MovementVector)
        {
            e_InputStateEnum = InputStateEnum.MOVING;
        }

        private void Idle()
        {
            e_InputStateEnum = InputStateEnum.IDLE;
        }

        private void SpellcastingModeActivate()
        {
            e_InputStateEnum = InputStateEnum.SPELLCASTING;
        }

        private void NotebookModeActivate()
        {
            e_InputStateEnum = InputStateEnum.NOTEBOOK;
        }

        private void StartedConversation(string[] pa_NpcNames)
        {
            e_InputStateEnum = InputStateEnum.CONVERSATION;
        }

        private void StartedInpecting(string[] pa_ItemNames)
        {
            e_InputStateEnum = InputStateEnum.INSPECTING;
        }

        public InputStateEnum CurrentStatus()
        {
            return e_InputStateEnum;
        }
    }
}
