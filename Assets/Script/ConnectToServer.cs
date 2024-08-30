using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public string sceneName;
    public TextMeshProUGUI playerName;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To Master");
    }
    public void JoinLobby()
    {
        PhotonNetwork.NickName = playerName.text;
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Lobby joined");
        SceneManager.LoadScene(sceneName);
        Debug.Log(PhotonNetwork.CurrentLobby.Name);
    }

}
