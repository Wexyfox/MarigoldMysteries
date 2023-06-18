using UnityEngine;
using UnityEngine.InputSystem;

namespace MarigoldMysteries
{
    public class SpellcastModeInvoker : MonoBehaviour
    {
        [Header("Action Map")]
        [SerializeField] private PlayerInputActionMap am_PlayerInputActionMap;

        [Header("Dependent Scripts")]
        [SerializeField] private PlayerState s_PlayerState;

        private void OnEnable()
        {
            am_PlayerInputActionMap.Triggers.SpellcastingModeToggle.performed += SpellcastingModeToggle;
            am_PlayerInputActionMap.Triggers.SpellcastingModeToggle.Enable();
        }

        private void OnDisable()
        {
            am_PlayerInputActionMap.Triggers.SpellcastingModeToggle.performed -= SpellcastingModeToggle;
            am_PlayerInputActionMap.Triggers.SpellcastingModeToggle.Disable();
        }

        private void SpellcastingModeToggle(InputAction.CallbackContext pa_Callback)
        {
            bool l_Idle = s_PlayerState.CurrentStatus() == InputStateEnum.IDLE;
            bool l_Spellcasting = s_PlayerState.CurrentStatus() == InputStateEnum.SPELLCASTING;

            if (!(l_Idle || l_Spellcasting))
            {
                return;
            }

            if (l_Spellcasting)
            {
                SpellcastingEvents.InvokeSpellcastingModeDeactivate();
                return;
            }

            SpellcastingEvents.InvokeSpellcastingModeActivate();
        }
    }
}
