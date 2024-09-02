using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class RoomListing : MonoBehaviour
{
    private TMP_Text _roomListingText;

    public RoomInfo roomInfo { get; set; }

    private void Awake()
    {
        _roomListingText = GetComponentInChildren<TMP_Text>();
    }
    public void SetRoomInfo(RoomInfo _roomInfo)
    {
        roomInfo = _roomInfo;
        _roomListingText.text = roomInfo.MaxPlayers + " | " + roomInfo.Name;
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);
    }
}
