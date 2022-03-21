// Script created by Centauri, as part of the SimpleAI unitypackage!

using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace SimpleAI
{
    public class DoggoFollowToggle : UdonSharpBehaviour
    {
        [Header("Follow Toggle")] [Tooltip("The main controller for the target AI!")]
        public BasicToggleableAI AIController;

        public override void Interact()
        {
            // Assigns new state relative to last state!
            if (AIController.CurrentState == 0)
            {
                AIController.CurrentState = 1;
            }
            else if (AIController.CurrentState == 1)
            {
                AIController.CurrentState = 0;
            }
        }
    }
}
