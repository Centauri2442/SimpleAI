// Script created by Centauri, as part of the SimpleAI unitypackage!

using System;
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using VRC.Udon.Common.Interfaces;

namespace SimpleAI
{
    public class SyncedDetectionSphere : UdonSharpBehaviour
    {
        [Header("Synced Guard Detection!")] [Tooltip("AI Controller reference!")]
        public BasicSyncedAI AIController;

        [Tooltip("The pool is used to get the list of all players!")]
        public SimpleAIObjectPool Pool;

        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            for (int i = 0; i < Pool.AllPlayers.Length; i++) // Compares current player to all existing players in the pool!
            {
                if (player == Pool.AllPlayers[i])
                {
                    SendCustomNetworkEvent(NetworkEventTarget.All, String.Concat("TargetPlayer" + (i + 1))); // Tells everyone who entered the trigger by calling the function specific to each player!
                    break;
                }
            }
        }

        /// <summary>
        /// public void TargetPlayerNUM()
        /// {
        ///    AIController.TargetPlayer = Pool.AllPlayers[NUM-1]; The player array startes at 0, so ensure it is the player number minus 1!
        ///    AIController.CurrentState = 4;
        /// }
        /// </summary>

        #region TargetPlayers

        public void TargetPlayer1()
        {
            AIController.TargetPlayer = Pool.AllPlayers[0];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer2()
        {
            AIController.TargetPlayer = Pool.AllPlayers[1];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer3()
        {
            AIController.TargetPlayer = Pool.AllPlayers[2];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer4()
        {
            AIController.TargetPlayer = Pool.AllPlayers[3];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer5()
        {
            AIController.TargetPlayer = Pool.AllPlayers[4];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer6()
        {
            AIController.TargetPlayer = Pool.AllPlayers[5];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer7()
        {
            AIController.TargetPlayer = Pool.AllPlayers[6];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer8()
        {
            AIController.TargetPlayer = Pool.AllPlayers[7];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer9()
        {
            AIController.TargetPlayer = Pool.AllPlayers[8];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer10()
        {
            AIController.TargetPlayer = Pool.AllPlayers[9];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer11()
        {
            AIController.TargetPlayer = Pool.AllPlayers[10];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer12()
        {
            AIController.TargetPlayer = Pool.AllPlayers[11];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer13()
        {
            AIController.TargetPlayer = Pool.AllPlayers[12];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer14()
        {
            AIController.TargetPlayer = Pool.AllPlayers[13];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer15()
        {
            AIController.TargetPlayer = Pool.AllPlayers[14];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer16()
        {
            AIController.TargetPlayer = Pool.AllPlayers[15];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer17()
        {
            AIController.TargetPlayer = Pool.AllPlayers[16];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer18()
        {
            AIController.TargetPlayer = Pool.AllPlayers[17];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer19()
        {
            AIController.TargetPlayer = Pool.AllPlayers[18];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer20()
        {
            AIController.TargetPlayer = Pool.AllPlayers[19];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer21()
        {
            AIController.TargetPlayer = Pool.AllPlayers[20];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer22()
        {
            AIController.TargetPlayer = Pool.AllPlayers[21];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer23()
        {
            AIController.TargetPlayer = Pool.AllPlayers[22];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer24()
        {
            AIController.TargetPlayer = Pool.AllPlayers[23];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer25()
        {
            AIController.TargetPlayer = Pool.AllPlayers[24];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer26()
        {
            AIController.TargetPlayer = Pool.AllPlayers[25];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer27()
        {
            AIController.TargetPlayer = Pool.AllPlayers[26];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer28()
        {
            AIController.TargetPlayer = Pool.AllPlayers[27];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer29()
        {
            AIController.TargetPlayer = Pool.AllPlayers[28];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer30()
        {
            AIController.TargetPlayer = Pool.AllPlayers[29];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer31()
        {
            AIController.TargetPlayer = Pool.AllPlayers[30];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer32()
        {
            AIController.TargetPlayer = Pool.AllPlayers[31];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer33()
        {
            AIController.TargetPlayer = Pool.AllPlayers[32];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer34()
        {
            AIController.TargetPlayer = Pool.AllPlayers[33];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer35()
        {
            AIController.TargetPlayer = Pool.AllPlayers[34];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer36()
        {
            AIController.TargetPlayer = Pool.AllPlayers[35];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer37()
        {
            AIController.TargetPlayer = Pool.AllPlayers[36];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer38()
        {
            AIController.TargetPlayer = Pool.AllPlayers[37];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer39()
        {
            AIController.TargetPlayer = Pool.AllPlayers[38];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer40()
        {
            AIController.TargetPlayer = Pool.AllPlayers[39];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer41()
        {
            AIController.TargetPlayer = Pool.AllPlayers[40];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer42()
        {
            AIController.TargetPlayer = Pool.AllPlayers[41];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer43()
        {
            AIController.TargetPlayer = Pool.AllPlayers[42];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer44()
        {
            AIController.TargetPlayer = Pool.AllPlayers[43];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer45()
        {
            AIController.TargetPlayer = Pool.AllPlayers[44];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer46()
        {
            AIController.TargetPlayer = Pool.AllPlayers[45];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer47()
        {
            AIController.TargetPlayer = Pool.AllPlayers[46];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer48()
        {
            AIController.TargetPlayer = Pool.AllPlayers[47];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer49()
        {
            AIController.TargetPlayer = Pool.AllPlayers[48];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer50()
        {
            AIController.TargetPlayer = Pool.AllPlayers[49];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer51()
        {
            AIController.TargetPlayer = Pool.AllPlayers[50];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer52()
        {
            AIController.TargetPlayer = Pool.AllPlayers[51];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer53()
        {
            AIController.TargetPlayer = Pool.AllPlayers[52];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer54()
        {
            AIController.TargetPlayer = Pool.AllPlayers[53];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer55()
        {
            AIController.TargetPlayer = Pool.AllPlayers[54];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer56()
        {
            AIController.TargetPlayer = Pool.AllPlayers[55];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer57()
        {
            AIController.TargetPlayer = Pool.AllPlayers[56];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer58()
        {
            AIController.TargetPlayer = Pool.AllPlayers[57];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer59()
        {
            AIController.TargetPlayer = Pool.AllPlayers[58];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer60()
        {
            AIController.TargetPlayer = Pool.AllPlayers[59];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer61()
        {
            AIController.TargetPlayer = Pool.AllPlayers[60];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer62()
        {
            AIController.TargetPlayer = Pool.AllPlayers[61];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer63()
        {
            AIController.TargetPlayer = Pool.AllPlayers[62];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer64()
        {
            AIController.TargetPlayer = Pool.AllPlayers[63];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer65()
        {
            AIController.TargetPlayer = Pool.AllPlayers[64];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer66()
        {
            AIController.TargetPlayer = Pool.AllPlayers[65];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer67()
        {
            AIController.TargetPlayer = Pool.AllPlayers[66];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer68()
        {
            AIController.TargetPlayer = Pool.AllPlayers[67];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer69()
        {
            AIController.TargetPlayer = Pool.AllPlayers[68];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer70()
        {
            AIController.TargetPlayer = Pool.AllPlayers[69];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer71()
        {
            AIController.TargetPlayer = Pool.AllPlayers[70];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer72()
        {
            AIController.TargetPlayer = Pool.AllPlayers[71];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer73()
        {
            AIController.TargetPlayer = Pool.AllPlayers[72];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer74()
        {
            AIController.TargetPlayer = Pool.AllPlayers[73];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer75()
        {
            AIController.TargetPlayer = Pool.AllPlayers[74];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer76()
        {
            AIController.TargetPlayer = Pool.AllPlayers[75];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer77()
        {
            AIController.TargetPlayer = Pool.AllPlayers[76];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer78()
        {
            AIController.TargetPlayer = Pool.AllPlayers[77];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer79()
        {
            AIController.TargetPlayer = Pool.AllPlayers[78];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer80()
        {
            AIController.TargetPlayer = Pool.AllPlayers[79];
            AIController.CurrentState = 4;
        }

        public void TargetPlayer81()
        {
            AIController.TargetPlayer = Pool.AllPlayers[80];
            AIController.CurrentState = 4;
        }

        #endregion
    }
}
