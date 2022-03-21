// Script created by Centauri, as part of the SimpleAI unitypackage!

using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace SimpleAI
{
    public class DoggoFollowToggleFetchAI : UdonSharpBehaviour
    {
        [Header("Follow Toggle!")] [Tooltip("Number of states that can be toggled between! Don't include special states such as fetch states in this counter!")]
        public int NumOfStates = 4;

        [Tooltip("The main controller for the target AI!")]
        public FetchAI AIController;

        public override void Interact()
        {
            // Assigns new state relative to last state!
            if (AIController.CurrentState < NumOfStates - 1)
            {
                AIController.CurrentState++;
            }
            else if (AIController.CurrentState >= NumOfStates - 1)
            {
                AIController.CurrentState = 0;
            }

            Debug.Log("New state is | " + AIController.CurrentState);
        }
    }
}
