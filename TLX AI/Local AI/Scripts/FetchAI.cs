// Script created by Centauri, as part of the SimpleAI unitypackage!

using UdonSharp;
using UnityEngine;
using UnityEngine.AI;
using VRC.SDKBase;
using VRC.Udon;

namespace SimpleAI
{
    public class FetchAI : UdonSharpBehaviour
{
    [Header("Fetch AI")]
    
    public int CurrentState; // The AIs internal state!
    // 0 - Wandering
    // 1 - Follow Player
    // 2 - Stand Still
    // 3 - Guard
    // 4 - GuardAgitated
    // 5 - Fetch Wait
    // 6 - Fetch Grab
    
    [Tooltip("This is the fetchable object! Each AI can only have 1!")]
    public FetcherPickup Fetchable;

    [Tooltip("This is the max distance the AI will wander from it's current position at once!")]
    public float MaxWanderDistance = 5f;
    [Tooltip("This is how long the AI will wait once it reaches it's new position while wandering!")]
    public float WanderIdleTime = 5f;

    [Tooltip("This animator is where the variables inside the script will be sent to!")]
    public Animator AIAnimator;

    [Space]
    [Header("Guard Variables")]
    [Tooltip("Collider used to detect players around the AI!")]
    public Collider GuardDetectionTrigger;
    [Tooltip("Time the AI will chase the player before reverting to its guard state!")]
    public float GuardChaseTime = 15f;
    
    private float GCTInternalTime; // Internal clock for the guard chase time
    private Vector3 GuardPos; // Internal guard position saved every time the AI first enters its guard state!
    
    private bool IsMovingToNext; // Checking if the AI is in the process of moving to the next waypoint
    private bool HasSetNextPosition; // Used for checking if a new position has been generated
    private float InternalWaitTime; // Wandering idle wait time internal counter
    
    private NavMeshAgent Agent; // The AI's main agent
    private VRCPlayerApi TargetPlayer; // The PlayerApi of the target player. For local AIs, this will always be the local player!

    private void Start()
    {
        // Set variables!
        Agent = GetComponent<NavMeshAgent>();
        TargetPlayer = Networking.LocalPlayer;
        InternalWaitTime = WanderIdleTime;

        IsMovingToNext = false;
        GCTInternalTime = GuardChaseTime;
    }
    
    private void Update()
    {
        // Feed AI info into the animator
        AIAnimator.SetInteger("State", CurrentState);
        AIAnimator.SetFloat("Velocity", Agent.velocity.magnitude);
        AIAnimator.SetBool("IsJumping", Agent.isOnOffMeshLink);
        
        GuardDetectionTrigger.gameObject.SetActive(CurrentState == 3); // Sets detection state based on if the AI state is 3!
        
        switch (CurrentState)
        {
            case 0: // Wander
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

                break;
            case 1: // Target Player
                SetAIDestination(TargetPlayer.GetPosition()); // Sets AI target to the target players root position every update!
                break;
            case 2: // Stand Still
                break;
            case 3: // Guard
                GuardPos = transform.position; // While the guard is not in its agitated state, it will set it's guard position to its current position!
                GCTInternalTime = GuardChaseTime; // Resets internal timer!
                break;
            case 4: // Guard Agitated
                SetAIDestination(TargetPlayer.GetPosition()); // The AI now targets the player, chasing their root position!
                
                // Timer
                GCTInternalTime -= Time.deltaTime;
                if (GCTInternalTime < 0f)
                {
                    // Resets back to its default guard state once it no longer is agitated!
                    CurrentState = 3;
                    GCTInternalTime = GuardChaseTime;
                    SetAIDestination(GuardPos);
                }
                break;
            case 5: // Targets player as part of fetching!
                SetAIDestination(TargetPlayer.GetPosition());
                break;
            case 6: // Targets fetchable as part of fetching!
                SetAIDestination(Fetchable.transform.position);
                break;
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
