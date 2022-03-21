// Script created by Centauri, as part of the SimpleAI unitypackage!

using UdonSharp;
using UnityEngine;
using UnityEngine.AI;
using VRC.SDK3.Components;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace SimpleAI
{
    public class SyncedFetcherPickup : UdonSharpBehaviour
    {
        [Header("Synced Fetchable Object")] [Tooltip("AI Controller reference")]
        public BasicSyncedAI AIController;

        [Tooltip("Transform position the fetchable attaches itself to when being carried by the AI")]
        public Transform AIGrabPoint;

        [Tooltip("Object sync reference! This is needed to for discontinuity checks!")]
        public VRCObjectSync OSync;

        private bool HasFlaggedDiscontinuity; // Internal discontinuity check

        [Tooltip("Internal check for if the fetchable object is currently in the process of being fetched!")]
        public bool IsBeingFetched;

        [Tooltip("Minimum distance from the player the fetchable object needs to be in order for it to be a valid throw!")]
        public float MinDistance = 5f;

        private Rigidbody rb; // Internal rigidbody variable
        private VRCPickup Pickup; // Internal Pickup variable
        private bool IsBeingThrown; // Internal throw check
        private bool IsBeingCarriedBack; // Internal carry check

        private VRCPlayerApi LocalPlayer; // Local Player VRCPlayerApi
        private NavMeshAgent Agent; // AI Agent

        public bool IsGrabbing;

        private void Start()
        {
            // Assign variables!
            rb = GetComponent<Rigidbody>();
            LocalPlayer = Networking.LocalPlayer;
            Agent = AIController.transform.GetComponent<NavMeshAgent>();
            Pickup = ((VRCPickup) GetComponent(typeof(VRCPickup)));
        }

        public override void OnPickup()
        {
            // Forces AI to fetch state when picked up
            IsBeingFetched = false;
            IsBeingThrown = false;

            IsGrabbing = true;

            if (Networking.IsOwner(Agent.gameObject)) // Ensures the relevant player is the owner of the object to allow them to play fetch!
            {
                AIController.CurrentState = 5;
            }
            else
            {
                Networking.SetOwner(Networking.LocalPlayer, Agent.gameObject);
            }
        }

        public override void OnOwnershipTransferred(VRCPlayerApi player)
        {
            // Sets relevant synced variables once ownership transfer is complete!
            if (IsGrabbing)
            {
                AIController.CurrentState = 5;
            }
        }

        public override void OnDrop()
        {
            // Begins throw check on drop!
            IsBeingThrown = true;
            IsGrabbing = false;
        }

        private void Update()
        {
            if (!Networking.IsOwner(Agent.gameObject)) return; // All update code only needs to run if the relevant player is the owner! If not, everything is handled for them!

            if (IsBeingThrown && Vector3.Distance(LocalPlayer.GetPosition(), transform.position) > MinDistance) // Fires when the fetchable is beyond the minimum distance after thrown!
            {
                if (rb.IsSleeping()) // Waits until the fetchable has properly landed, based on if it is sleeping! (Not moving)
                {
                    // Calculates navmesh path between the AI and the fetchable
                    NavMeshPath PathTest = new NavMeshPath();
                    Agent.CalculatePath(transform.position, PathTest);

                    // Checks if the path is valid!
                    if (PathTest.status == NavMeshPathStatus.PathComplete)
                    {
                        // If valid, the AI will now attempt to grab the fetchable!
                        IsBeingThrown = false;
                        IsBeingFetched = true;
                        AIController.CurrentState = 6;
                    }
                    else
                    {
                        // If not valid, the AI will keep its current state, and the fetchable will be reset!
                        IsBeingThrown = false;
                        AIController.CurrentState = 5;
                        ResetPickup();
                    }
                }
            }

            if (IsBeingFetched && !IsBeingCarriedBack &&
                (Agent.velocity.magnitude < 0.2f && Vector3.Distance(Agent.transform.position, transform.position) <= Agent.stoppingDistance + 1f))
            {
                // Once the AI has reached the pickup, it will now take it and begin carrying it back to the player!
                AITakePickup();
            }

            if (IsBeingCarriedBack)
            {
                if (!HasFlaggedDiscontinuity) // Flags discontinuity! This makes the fetchable properly move to its new position without network based lerping!
                {
                    OSync.FlagDiscontinuity();
                    HasFlaggedDiscontinuity = true;
                }

                transform.SetPositionAndRotation(AIGrabPoint.position, AIGrabPoint.rotation); // While being carried back, the fetchable's position will be set to the grab point!
                AIController.CurrentState = 5; // Will force the AI to stay in the fetching state until the AI has completed bringing it back!

                if ((Agent.velocity.magnitude < 0.2f &&
                     Vector3.Distance(Agent.transform.position, LocalPlayer.GetPosition()) <= Agent.stoppingDistance + 1f)) // Fires once the AI has reached the player!
                {
                    IsBeingCarriedBack = false;
                    IsBeingThrown = false;
                    IsBeingFetched = false;

                    HasFlaggedDiscontinuity = false;

                    AIController.CurrentState = 1;
                    SendCustomNetworkEvent(NetworkEventTarget.All, nameof(SetPickupable)); // Ensures all players can grab the pickup again!
                }
            }
        }

        public void SetPickupable()
        {
            Pickup.pickupable = true;
        }

        public void SetNotPickupable()
        {
            Pickup.pickupable = false;
        }

        private void AITakePickup()
        {
            // Grabs fetchable and ensures it can't be stolen by a player!
            IsBeingCarriedBack = true;
            Pickup.pickupable = false;
        }

        public void ResetPickup()
        {
            // Resets fetchable to the players right hand!
            transform.position = LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.RightHand).position;
        }
    }
}
