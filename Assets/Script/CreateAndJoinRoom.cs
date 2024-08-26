using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI createRoomName;
    public TextMeshProUGUI joinRoomName;
    public string sceneName;
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomName.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomName.text);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Room Created by the name : " + createRoomName.text);
        //SceneManager.LoadScene(sceneName);
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Room Join in : " +  joinRoomName.text);
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

}
