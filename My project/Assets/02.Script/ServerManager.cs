using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ServerManager : MonoBehaviourPunCallbacks
{
    //public Button connect;
    public TMP_Text region;
    //public TMP_Text lobby;
    public TMP_Text room;
    public Button Room1, Room2, Room3;
    public TMP_InputField RoomName;

    Dictionary<string, RoomInfo> RoomCatalog = new Dictionary<string, RoomInfo>();

    public void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("01.Scenes/02.Server");
    }

    public void Update()
    {
        region.text = PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion;

        switch (Data.count)
        {
            case 0:
                room.text = "시계 판매점";
                break;
            case 1:
                room.text = "오락실 뽑기방";
                break;
            case 2:
                room.text = "자동차 전시관";
                break;
        }
        Room1.interactable = true;
        Room2.interactable = true;
        Room3.interactable = true;
        //RoomCreate.interactable = true;

    }
    public void OnClickCreateRoom()
    {
        switch (Data.count)
        {
            case 0:
                RoomOptions Room1 = new RoomOptions();
                Room1.MaxPlayers = 8;
                Room1.IsOpen = true;
                Room1.IsVisible = true;
                PhotonNetwork.CreateRoom(RoomName.text, Room1);
                break;
            case 1:
                RoomOptions Room2 = new RoomOptions();
                Room2.MaxPlayers = 8;
                Room2.IsOpen = true;
                Room2.IsVisible = true;
                PhotonNetwork.CreateRoom(RoomName.text, Room2);
                break;
            case 2:
                RoomOptions Room3 = new RoomOptions();
                Room3.MaxPlayers = 8;
                Room3.IsOpen = true;
                Room3.IsVisible = true;
                PhotonNetwork.CreateRoom(RoomName.text, Room3);
                break;
        }
    }

    public void OnClickJoinRoom()
    {        
        PhotonNetwork.JoinRoom(RoomName.text);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log($"현재 방 갯수 : {roomList.Count}");
    }

    public override void OnJoinedRoom()
    {
        switch (Data.count)
        {
            case 0:
                PhotonNetwork.LoadLevel("01.Scenes/03.WatchShow");
                break;
            case 1:
                PhotonNetwork.LoadLevel("01.Scenes/03.FurnShow");
                break;
            case 2:
                PhotonNetwork.LoadLevel("01.Scenes/03.CarShow");
                break;
        }
    }
}
