using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Chat;
using ExitGames.Client.Photon;
using TMPro;

public class ChatListner : MonoBehaviour, IChatClientListener
{
    private ChatClient chatClient;
    private void Start()
    {
        chatClient = new ChatClient(this);
    }
    void IChatClientListener.DebugReturn(DebugLevel level, string message)
    {
        throw new System.NotImplementedException();
    }

    void IChatClientListener.OnChatStateChange(ChatState state)
    {
        throw new System.NotImplementedException();
    }

    void IChatClientListener.OnConnected()
    {
        throw new System.NotImplementedException();
    }

    void IChatClientListener.OnDisconnected()
    {
        throw new System.NotImplementedException();
    }

    void IChatClientListener.OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        throw new System.NotImplementedException();
    }

    void IChatClientListener.OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }

    void IChatClientListener.OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }

    void IChatClientListener.OnSubscribed(string[] channels, bool[] results)
    {
        throw new System.NotImplementedException();
    }

    void IChatClientListener.OnUnsubscribed(string[] channels)
    {
        throw new System.NotImplementedException();
    }

    void IChatClientListener.OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    void IChatClientListener.OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }
}
