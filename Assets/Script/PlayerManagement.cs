using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagement : MonoBehaviourPunCallbacks
{
    public Transform content;
    public PlayerListing playerListing; 
    public List<PlayerListing> listingList = new List<PlayerListing>();

    private void Awake()
    {
        GetCurrentRoomPlayer();
    }
    void GetCurrentRoomPlayer()
    {
        foreach(KeyValuePair<int,Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }
    void AddPlayerListing(Player player)
    {
        PlayerListing listing = Instantiate(playerListing,content);

        if(listing != null)
        {
            listing.SetPlayerInfo(player);
            listingList.Add(listing);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //for (int i = 0; i < listingList.Count; i++)
        //{
        //    if (listingList[i].playerInfo == otherPlayer)
        //    {
        //        Destroy(listingList[i]);
        //        listingList.RemoveAt(i);
        //        break;
        //    }
        //}

        int index = listingList.FindIndex(x => x.playerInfo == otherPlayer);
        if (index != -1)
        {
            Destroy(listingList[index]);
            listingList.RemoveAt(index);
        }
    }
}
