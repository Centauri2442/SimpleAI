// ALL OBJECT POOL CODE BASED OFF OF PHASEDRAGON's SIMPLEOBJECTPOOL PREFAB!
// All credit to Phasedragon!

using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace SimpleAI
{
    public class Player : UdonSharpBehaviour
    {
        private SimpleAIObjectPool Pool;
        private VRCPlayerApi Owner;

        private void Start()
        {
            Pool = transform.parent.GetComponent<SimpleAIObjectPool>();
        }
        public void UpdateOwner() 
        {
            Owner = Networking.GetOwner(gameObject); //Setting the owner is important in order to keep track of the correct player. This can be removed if you use DoNotTransferOwnership
            if (Owner == null) return;
        }
        public override void OnPlayerLeft(VRCPlayerApi player) //Setting owner to null is important in order to prevent script crashing from an invalid playerapi
        {
            if (Owner == player)
            {
                Owner = null;
            }
        }
    }
}
