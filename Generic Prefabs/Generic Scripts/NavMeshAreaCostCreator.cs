// Script created by Centauri, as part of the SimpleAI unitypackage!

using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

namespace SimpleAI
{
    public class NavMeshAreaCostCreator : UdonSharpBehaviour
    {
        [Header("NavMesh Area Modifier Script")]
    
        [Tooltip("All 32 areas have a set cost. You can modify them here!")] 
        public int[] AllAreaCosts;

        [Tooltip("If you want to have a debug log of all the layers on a UI, set it here!")] 
        public Text DebugLog;
    
        void Start()
        {
            // By default, all costs are 1
        
            for (int i = 0; i < AllAreaCosts.Length; i++) // Goes through each area, and if the cost is not default, changes it.
            {
                if (AllAreaCosts[i] != 1)
                {
                    NavMesh.SetAreaCost(i, AllAreaCosts[i]);
                }
            
            
                if (DebugLog != null) // Displays debug info, with some formatting stuff
                {
                    if (i < 1)
                    {
                        DebugLog.text = "Area 0" + i + " Layer Cost |  " + AllAreaCosts[i];
                    }
                    else if (i < 10 && i > 0)
                    {
                        DebugLog.text = DebugLog.text + "\n" + "Area 0" + i + " Layer Cost |  " + AllAreaCosts[i];
                    }
                    else
                    {
                        DebugLog.text = DebugLog.text + "\n" + "Area " + i + " Layer Cost |  " + AllAreaCosts[i];
                    }
                }
            }
        }
    }
}
