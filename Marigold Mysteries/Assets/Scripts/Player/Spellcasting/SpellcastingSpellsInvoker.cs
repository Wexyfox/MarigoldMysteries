using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MarigoldMysteries
{
    public class SpellcastingSpellsInvoker : MonoBehaviour
    {
        [Header("Action Map")]
        [SerializeField] private PlayerInputActionMap am_PlayerInputActionMap;

        [Header("Dependent Scripts")]
        [SerializeField] private PlayerState s_PlayerState;

        [Header("Internal Values")]
        [SerializeField] private string pr_SpellComponents;
        [SerializeField] private bool pr_StartedCasting;

        [Header("Spellcasting Values")]
        [SerializeField] private int pr_DisableDelayMiliseconds = 3000;        

        private char pr_SpellUpChar = char.Parse("u");
        private char pr_SpellDownChar = char.Parse("d");
        private char pr_SpellLeftChar = char.Parse("l");
        private char pr_SpellRightChar = char.Parse("r");

        #region Input Action Map Subscriptions
        private void OnEnable()
        {
            am_PlayerInputActionMap.SpellCasting.SpellUp.performed += SpellUp;
            am_PlayerInputActionMap.SpellCasting.SpellDown.performed += SpellDown;
            am_PlayerInputActionMap.SpellCasting.SpellLeft.performed += SpellLeft;
            am_PlayerInputActionMap.SpellCasting.SpellRight.performed += SpellRight;
            am_PlayerInputActionMap.SpellCasting.Enable();
        }

        private void OnDisable()
        {
            am_PlayerInputActionMap.SpellCasting.SpellUp.performed -= SpellUp;
            am_PlayerInputActionMap.SpellCasting.SpellDown.performed -= SpellDown;
            am_PlayerInputActionMap.SpellCasting.SpellLeft.performed -= SpellLeft;
            am_PlayerInputActionMap.SpellCasting.SpellRight.performed -= SpellRight;
            am_PlayerInputActionMap.SpellCasting.Disable();
        }
        #endregion

        private void SpellUp(InputAction.CallbackContext pa_Callback)
        {
            SpellInput(pr_SpellUpChar);
        }

        private void SpellDown(InputAction.CallbackContext pa_Callback)
        {
            SpellInput(pr_SpellDownChar);
        }

        private void SpellLeft(InputAction.CallbackContext pa_Callback)
        {
            SpellInput(pr_SpellLeftChar);
        }

        private void SpellRight(InputAction.CallbackContext pa_Callback)
        {
            SpellInput(pr_SpellRightChar);
        }

        private void SpellInput(char pa_InputChar)
        {
            if (s_PlayerState.CurrentStatus() != InputStateEnum.SPELLCASTING)
            {
                return;
            }

            if (!pr_StartedCasting)
            {
                pr_StartedCasting = true;
                SpellcastingEvents.InvokeStartedCasting();
                DelayDisable();
            }

            pr_SpellComponents += pa_InputChar;
        }

        private async void DelayDisable()
        {
            await Task.Delay(pr_DisableDelayMiliseconds);
            SpellChecks();

            if (pr_StartedCasting)
            {
                Disable();
            }
        }

        private void Disable()
        {
            pr_StartedCasting = false;
            pr_SpellComponents = "";
            SpellcastingEvents.InvokeSpellcastingModeDeactivate();
        }

        private void SpellChecks()
        {
            switch (pr_SpellComponents)
            {
                case "dr":
                    SpellcastingEvents.InvokeCastedLightSpell();
                    Disable();
                    break;
                case "drrud":
                    SpellcastingEvents.InvokeCastedUVLightSpell();
                    Disable();
                    break;
                case "durddl":
                    SpellcastingEvents.InvokeCastedRevealSpell();
                    Disable();
                    break;
                default:
                    SpellcastingEvents.InvokeSpellFizzle();
                    Disable();
                    break;
            }
        }
    }
}
