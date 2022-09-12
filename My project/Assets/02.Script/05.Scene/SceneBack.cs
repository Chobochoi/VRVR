using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class SceneBack : MonoBehaviourPunCallbacks
{
   private void OnExitClick()
    {
        PhotonNetwork.LeaveRoom();
    }
    
   public override void OnLeftRoom()
   {
        SceneManager.LoadScene("01.Scenes/04.Show");
   }
}
