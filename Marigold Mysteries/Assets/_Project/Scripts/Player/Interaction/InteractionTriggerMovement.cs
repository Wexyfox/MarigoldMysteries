using UnityEngine;

namespace MarigoldMysteries
{
    public class InteractionTriggerMovement : MonoBehaviour
    {
        [SerializeField] private BoxCollider2D u_BoxCollider2D;

        private Vector2 pr_UpPositionVector;
        private Vector2 pr_DownPositionVector;
        private Vector2 pr_LeftPositionVector;
        private Vector2 pr_RightPositionVector;

        private void Awake()
        {
            pr_UpPositionVector = new Vector2(0, 0);
            pr_DownPositionVector = new Vector2(0, -0.35f);
            pr_LeftPositionVector = new Vector2(-0.2f, -0.15f);
            pr_RightPositionVector = new Vector2(0.2f, -0.15f);
        }

        private void OnEnable()
        {
            MovementEvents.Movement += Movement;
        }

        private void OnDisable()
        {
            MovementEvents.Movement -= Movement;
        }

        private void Movement(Vector2 pa_MovementVector)
        {
            switch (pa_MovementVector.x)
            {
                case < 0:
                    SetOffset(pr_LeftPositionVector);
                    break;
                case > 0:
                    SetOffset(pr_RightPositionVector);
                    break;
            }

            switch (pa_MovementVector.y)
            {
                case > 0:
                    SetOffset(pr_UpPositionVector);
                    break;
                case < 0:
                    SetOffset(pr_DownPositionVector);
                    break;
            }
        }

        private void SetOffset(Vector2 pa_OffsetVector)
        {
            u_BoxCollider2D.offset = pa_OffsetVector;
        }
    }
}
