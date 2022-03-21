// Script created by Centauri, as part of the SimpleAI unitypackage!

using UdonSharp;
using UnityEngine;
using UnityEngine.AI;
using VRC.SDKBase;
using VRC.Udon;

namespace SimpleAI
{
    public class BasicWanderingAI : UdonSharpBehaviour
    {
        [Header("Basic Wandering AI")] [Space] [Tooltip("This is the max distance the AI will wander from it's current position at once!")]
        public float MaxWanderDistance = 5f;

        [Tooltip("This is how long the AI will wait once it reaches it's new position while wandering!")]
        public float WanderIdleTime = 5f;

        [Tooltip("This animator is where the variables inside the script will be sent to!")]
        public Animator AIAnimator;

        private bool IsMovingToNext; // Checking if the AI is in the process of moving to the next waypoint
        private bool HasSetNextPosition; // Used for checking if a new position has been generated
        private float InternalWaitTime; // Wandering idle wait time internal counter

        private NavMeshAgent Agent; // The AI's main agent
        private VRCPlayerApi TargetPlayer; // Unused in the wandering AI

        private void Start()
        {
            // Assign variables
            Agent = GetComponent<NavMeshAgent>();
            TargetPlayer = Networking.LocalPlayer;
            InternalWaitTime = WanderIdleTime;

            IsMovingToNext = false;
        }

        private void Update()
        {
            // Feed AI info into the animator
            AIAnimator.SetFloat("Velocity", Agent.velocity.magnitude);
            AIAnimator.SetBool("IsJumping", Agent.isOnOffMeshLink);

            if (!IsMovingToNext) // Runs while the AI is idle
            {
                HasSetNextPosition = false;

                InternalWaitTime -= Time.deltaTime;

                if (InternalWaitTime < 0f)
                {
                    IsMovingToNext = true;

                    InternalWaitTime = WanderIdleTime;

                    StartWandering(); // Starts wandering once the idle timer has ended!

                    //SendCustomEventDelayedSeconds(nameof(StartWandering), WanderIdleTime); Alternative to an internal timer
                }
            }

            if (Agent.remainingDistance < 1 // | Remaining distance must always be greater than the stopping distance!
                && HasSetNextPosition) //Makes sure a new position has been set!
            {
                IsMovingToNext = false;

                InternalWaitTime = WanderIdleTime;
            }
        }

        public void StartWandering() // Function used to force the AI to find a new random position!
        {
            SetAIDestination(CalculateRandomPosition(MaxWanderDistance));
        }

        public void SetAIDestination(Vector3 Target) // Used for setting the AI's next destination!
        {
            HasSetNextPosition = true;
            Agent.SetDestination(Target);
        }

        private Vector3 CalculateRandomPosition(float dist) // Calculates a navmesh position within specific distance constraints!
        {
            var randDir = transform.position + Random.insideUnitSphere * dist; // Finds a point within a 3D space around the AI!

            NavMeshHit hit;

            NavMesh.SamplePosition(randDir, out hit, dist, NavMesh.AllAreas); // Uses the calculated point to find the nearest navmesh position!

            return hit.position;
        }


    }
}
