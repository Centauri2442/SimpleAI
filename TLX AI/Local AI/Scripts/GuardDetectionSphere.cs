// Script created by Centauri, as part of the SimpleAI unitypackage!

using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace SimpleAI
{
    public class GuardDetectionSphere : UdonSharpBehaviour
    {
        [Header("Guard Detection Volume! ")] [Tooltip("AI Controller reference!")]
        public MultiStateAI AIController;

        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            // Sets the AI to follow the player if they enter the guard detection sphere!
            AIController.CurrentState = 4;
        }
    }
}
