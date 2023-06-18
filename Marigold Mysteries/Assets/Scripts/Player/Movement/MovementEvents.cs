using UnityEngine;
using UnityEngine.Events;

namespace MarigoldMysteries
{
    public static class MovementEvents
    {
        public static event UnityAction<Vector2> Movement;
        public static void InvokeMovement(Vector2 pa_MovementVector)
        {
            Movement?.Invoke(pa_MovementVector);
        }

        public static event UnityAction Idle;
        public static void InvokeIdle()
        {
            Idle?.Invoke();
        }
    }
}
