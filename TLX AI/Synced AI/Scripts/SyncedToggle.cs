// Script created by Centauri, as part of the SimpleAI unitypackage!

using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace SimpleAI
{
    public class SyncedToggle : UdonSharpBehaviour
    {
        [Header("Follow Toggle!")] [Tooltip("Number of states that can be toggled between! Don't include special states such as fetch states in this counter!")]
        public int NumOfStates = 4;

        [Tooltip("The main controller for the target AI!")]
        public BasicSyncedAI AIController;

        private bool IsOwnershipInteract; // Internal ownership check

        public override void Interact()
        {
            if (Networking.IsOwner(gameObject)) // Ensures the player is the owner of the target AI before changing the state, as the state is a synced variable!
            {
                ChangeState();
            }
            else
            {
                Networking.SetOwner(Networking.LocalPlayer, AIController.gameObject);
                Networking.SetOwner(Networking.LocalPlayer, gameObject);
                IsOwnershipInteract = true;
            }
        }

        public void ChangeState()
        {
            // Changes the state relative to its existing state!
            if (AIController.CurrentState < NumOfStates - 1)
            {
                AIController.CurrentState++;
            }
            else if (AIController.CurrentState >= NumOfStates - 1)
            {
                AIController.CurrentState = 0;
            }
        }

        public override void OnOwnershipTransferred(VRCPlayerApi player)
        {
            // Forces the change state function to fire once the relevant player has taken ownership of the AI!
            if (IsOwnershipInteract)
            {
                ChangeState();
                IsOwnershipInteract = false;
            }
        }
    }
}
