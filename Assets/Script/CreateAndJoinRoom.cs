using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Realtime;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI roomName;
    public string sceneName;
    public GameObject roomPanelPrefab;
    public void CreateOrJoinRoom()
    {
        //PhotonNetwork.CreateRoom(createRoomName.text);
        if(!PhotonNetwork.IsConnected)
        {
            return;
        }

        RoomOptions roomOptions = new RoomOptions
        {
            IsOpen = true,
            IsVisible = true,
            MaxPlayers = 4
        };
        PhotonNetwork.JoinOrCreateRoom(roomName.text, roomOptions, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        //Debug.Log("Room Created by the name : " + createRoomName.text);
        //SceneManager.LoadScene(sceneName);
    }
    public override void OnJoinedRoom()
    {
        //Debug.Log("Room Join in : " +  joinRoomName.text);
        PhotonNetwork.LoadLevel(sceneName);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Fail to create room");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Fail to Join Room");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(var info in roomList)
        {
            if(info.RemovedFromList)
            {

            }
            else
            {
                //var listing = Instantiate();
            }
        }
    }

}
