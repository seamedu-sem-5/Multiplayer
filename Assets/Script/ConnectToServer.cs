/*READ ME
 * This script connects a player to a Photon server,
 * sets their nickname, joins a lobby, and then loads
 * a specified scene upon successfully joining the lobby.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public string sceneName;
    public TextMeshProUGUI playerName;

    // Start is called before the first frame update
    void Start()
    {
        // Connect to the Photon server using settings
        PhotonNetwork.ConnectUsingSettings();
    }

    // Callback when connected to the Photon Master server
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master");
    }

    // Set the player's nickname and join the lobby
    public void JoinLobby()
    {
        PhotonNetwork.NickName = playerName.text;
        PhotonNetwork.JoinLobby();
    }

    // Callback when the lobby is successfully joined
    public override void OnJoinedLobby()
    {
        Debug.Log("Lobby joined");
        // Load the specified scene after joining the lobby
        PhotonNetwork.LoadLevel(sceneName);
        Debug.Log(PhotonNetwork.CurrentLobby.Name);
    }
}
