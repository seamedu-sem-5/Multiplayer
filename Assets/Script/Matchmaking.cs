using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using Unity.VisualScripting;
public class Matchmaking : IMatchmakingCallbacks
{
    void IMatchmakingCallbacks.OnCreatedRoom()
    {
        throw new System.NotImplementedException();
    }

    void IMatchmakingCallbacks.OnCreateRoomFailed(short returnCode, string message)
    {
        throw new System.NotImplementedException();
    }

    void IMatchmakingCallbacks.OnFriendListUpdate(List<FriendInfo> friendList)
    {
        throw new System.NotImplementedException();
    }

    void IMatchmakingCallbacks.OnJoinedRoom()
    {
        throw new System.NotImplementedException();
    }

    void IMatchmakingCallbacks.OnJoinRandomFailed(short returnCode, string message)
    {
        throw new System.NotImplementedException();
    }

    void IMatchmakingCallbacks.OnJoinRoomFailed(short returnCode, string message)
    {
        throw new System.NotImplementedException();
    }

    void IMatchmakingCallbacks.OnLeftRoom()
    {
        throw new System.NotImplementedException();
    }
}
