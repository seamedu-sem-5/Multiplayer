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
    public RoomListing roomListing;
    public GameObject scrollView;

    public List<RoomListing> listingList = new List<RoomListing>();
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
        Debug.Log("Room Join in ");
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
        
        foreach (var info in roomList)
        {
            Debug.Log("RoomList Update");
            RoomListing _roomListing = Instantiate(roomListing, scrollView.transform);

            if(_roomListing != null)
            {
                _roomListing.SetRoomInfo(info);
                listingList.Add(_roomListing);
            }

            if(info.RemovedFromList)
            {
                Debug.Log("Removed from List");

                for(int i=0;i<listingList.Count;i++)
                {
                    if(listingList[i].roomInfo.Name == info.Name)
                    {
                        Destroy(listingList[i].gameObject);
                        listingList.RemoveAt(i);
                    }
                }
            }
        }
    }

}
