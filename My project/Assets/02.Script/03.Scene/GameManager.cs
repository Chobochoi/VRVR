using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class GameManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.Instantiate("Player", new Vector3
            (Random.Range(0, 5), 1, Random.Range(0, 5)), Quaternion.identity);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LoadLevel("01.Scenes/02.Server");
        PhotonNetwork.LeaveRoom();
    }   

}
