/* READ ME
 * This script handles the display and joining of Photon rooms.
 * It updates the UI with room details and allows players to join
 * a room by clicking a button.
 */
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

    // Set room information and update the text display
    public void SetRoomInfo(RoomInfo _roomInfo)
    {
        roomInfo = _roomInfo;
        _roomListingText.text = roomInfo.MaxPlayers + " | " + roomInfo.Name;
    }

    // Join the room when called
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomInfo.Name);
    }
}

