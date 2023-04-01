using UnityEngine;
using UnityEngine.InputSystem;

namespace Controller_Hands
{
    public class HandsAnimationController : MonoBehaviour
    {
        [SerializeField] private InputActionProperty pinchAnimationAction;
        [SerializeField] private InputActionProperty gripAnimationAction;

        [SerializeField] private Animator handAnimator;
        
        private static readonly int Trigger = Animator.StringToHash("Trigger");
        private static readonly int Grip = Animator.StringToHash("Grip");

        private void Update()
        {
            HandlePinchAnimation();
            HandleGripAnimation();
        }

        private void HandlePinchAnimation()
        {
            var triggerValue = pinchAnimationAction.action.ReadValue<float>();
            handAnimator.SetFloat(Trigger, triggerValue);
        }

        private void HandleGripAnimation()
        {
            var gripValue = gripAnimationAction.action.ReadValue<float>();
            handAnimator.SetFloat(Grip, gripValue);
        }
    }
}
