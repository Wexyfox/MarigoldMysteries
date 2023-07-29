using UnityEngine.Events;

namespace MarigoldMysteries
{
    public static class SpellcastingEvents
    {
        public static event UnityAction SpellcastingModeActivate;
        public static void InvokeSpellcastingModeActivate()
        {
            SpellcastingModeActivate?.Invoke();
        }

        public static event UnityAction SpellcastingModeDeactivate;
        public static void InvokeSpellcastingModeDeactivate()
        {
            SpellcastingModeDeactivate?.Invoke();
        }

        public static event UnityAction StartedCasting;
        public static void InvokeStartedCasting()
        {
            StartedCasting?.Invoke();
        }

        public static event UnityAction SpellFizzle;
        public static void InvokeSpellFizzle()
        {
            SpellFizzle?.Invoke();
        }

        public static event UnityAction CastedLightSpell;
        public static void InvokeCastedLightSpell()
        {
            CastedLightSpell?.Invoke();
        }

        public static event UnityAction CastedUVLightSpell;
        public static void InvokeCastedUVLightSpell()
        {
            CastedUVLightSpell?.Invoke();
        }

        public static event UnityAction CastedRevealSpell;
        public static void InvokeCastedRevealSpell()
        {
            CastedRevealSpell?.Invoke();
        }
    }
}
