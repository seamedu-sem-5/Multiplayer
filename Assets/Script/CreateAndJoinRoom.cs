/*  READ ME
 * This script allows players to create or join a Photon room,
 * handles room creation/joining failures, updates the room list
 * in the UI, and loads a specified scene upon successfully joining a room.
 */
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI roomName;
    public string sceneName;
    public RoomListing roomListing;
    public GameObject scrollViewContent;

    public List<RoomListing> listingList = new List<RoomListing>(); // List to keep track of room listings

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Creates or joins a room with the specified name
    public void CreateOrJoinRoom()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return; // Exit if not connected to Photon
        }

        RoomOptions roomOptions = new RoomOptions
        {
            IsOpen = true,
            IsVisible = true,
            MaxPlayers = 4
        };

        PhotonNetwork.JoinOrCreateRoom(roomName.text, roomOptions, TypedLobby.Default);
    }

    // Called when a room is successfully joined
    public override void OnJoinedRoom()
    {
        Debug.Log("Room Joined");
        //PhotonNetwork.LoadLevel(sceneName); // Load the specified scene after joining
    }

    // Called when creating a room fails
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room");
    }

    // Called when joining a room fails
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join room");
    }

    // Updates the room list in the UI
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (var info in roomList)
        {
            Debug.Log("RoomList Update");

            // Instantiate a new RoomListing prefab
            RoomListing _roomListing = Instantiate(roomListing, scrollViewContent.transform);

            if (_roomListing != null)
            {
                _roomListing.SetRoomInfo(info);
                listingList.Add(_roomListing);
            }

            // Remove rooms that are no longer available
            if (info.RemovedFromList)
            {
                Debug.Log("Removed from List");

                for (int i = 0; i < listingList.Count; i++)
                {
                    if (listingList[i].roomInfo.Name == info.Name)
                    {
                        Destroy(listingList[i].gameObject);
                        listingList.RemoveAt(i);
                    }
                }
            }
        }
    }
    public void StartGame()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(sceneName);
        }
    }
}
