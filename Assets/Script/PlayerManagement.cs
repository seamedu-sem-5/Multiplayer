/*READ ME
 *The script maintains player listings by adding new players
 *to the user interface and eliminating listings when players
 *exit the room. 
 */
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
        // Initialize player listings for existing players in the room
        GetCurrentRoomPlayer();
    }

    // Retrieve and list current players in the room
    void GetCurrentRoomPlayer()
    {
        foreach(KeyValuePair<int,Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    // Create and add a player listing to the UI
    void AddPlayerListing(Player player)
    {
        PlayerListing listing = Instantiate(playerListing,content);

        if(listing != null)
        {
            listing.SetPlayerInfo(player);
            listingList.Add(listing);
        }
    }

    // Called when a new player enters the room
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    // Called when a player leaves the room
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

        //Find the index from the list
        int index = listingList.FindIndex(x => x.playerInfo == otherPlayer);
        if (index != -1)
        {
            Destroy(listingList[index].gameObject);// Destroy the player listing
            listingList.RemoveAt(index);// Remove from the list
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        //Debug.Log("OnPlayerPropertiesUpdate for " + targetPlayer.NickName);
        var currentPlayer = listingList.Find(x => x.playerInfo.NickName == targetPlayer.NickName);
        currentPlayer.SetScore(currentPlayer.playerInfo);
    }
}
