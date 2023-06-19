using UnityEngine;
using UnityEngine.Events;

namespace MarigoldMysteries
{
    public class InteractionListener : MonoBehaviour
    {
        public UnityEvent InteractedWith;

        public void Interact()
        {
            InteractedWith.Invoke();
        }
    }
}