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
            SpellcastingEvents.SpellcastingModeDeactivate += SpellcastingModeDeactivate;

            NotebookEvents.NotebookModeActivate += NotebookModeActivate;
            NotebookEvents.NotebookModeDeactivate += NotebookModeDeactivate;
        }

        private void OnDisable()
        {
            MovementEvents.Movement -= Movement;
            MovementEvents.Idle -= Idle;

            SpellcastingEvents.SpellcastingModeActivate += SpellcastingModeActivate;
            SpellcastingEvents.SpellcastingModeDeactivate += SpellcastingModeDeactivate;

            NotebookEvents.NotebookModeActivate -= NotebookModeActivate;
            NotebookEvents.NotebookModeDeactivate -= NotebookModeDeactivate;
        }
        #endregion

        #region Spellcasting Event Reactions
        private void SpellcastingModeActivate()
        {
            e_InputStateEnum = InputStateEnum.SPELLCASTING;
        }

        private void SpellcastingModeDeactivate()
        {
            e_InputStateEnum = InputStateEnum.IDLE;
        }
        #endregion

        #region Movement Event Reactions
        private void Movement(Vector2 pa_MovementVector)
        {
            e_InputStateEnum = InputStateEnum.MOVING;
        }

        private void Idle()
        {
            e_InputStateEnum = InputStateEnum.IDLE;
        }
        #endregion

        #region Notebook Event Reactions
        private void NotebookModeActivate()
        {
            e_InputStateEnum = InputStateEnum.NOTEBOOK;
        }

        private void NotebookModeDeactivate()
        {
            e_InputStateEnum = InputStateEnum.IDLE;
        }
        #endregion

        public InputStateEnum CurrentStatus()
        {
            return e_InputStateEnum;
        }
    }
}
