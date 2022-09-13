using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CharactorManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.Instantiate("Player", new Vector3
            (Random.Range(-4, 15), -1, Random.Range(-5, 5)), Quaternion.identity);
    }

    void Update()
    {
        
    }
}
