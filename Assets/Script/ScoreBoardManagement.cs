using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class ScoreBoardManagement : MonoBehaviourPunCallbacks
{
    public Transform content;
    public ScoreBoardListing scoreBoardListing;
    public List<ScoreBoardListing> listingList = new List<ScoreBoardListing>();

    private void Awake()
    {
        // Initialize player listings for existing players in the room
        GetCurrentRoomPlayer();
    }

    // Retrieve and list current players in the room
    void GetCurrentRoomPlayer()
    {
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }

    // Create and add a player listing to the UI
    void AddPlayerListing(Player player)
    {
        ScoreBoardListing listing = Instantiate(scoreBoardListing, content);

        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            listingList.Add(listing);
        }
        //SortScoreBoard();
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    private void SortScoreBoard()
    {
        ScoreBoardListing temp;

        for (int i = 0; i < listingList.Count - 1; i++)
        {
            for (int j = i + 1; j < listingList.Count; j++)
            {
                if (listingList[i].score < listingList[j].score)
                {

                    temp = listingList[i];
                    listingList[i] = listingList[j];
                    listingList[j] = temp;
                }
            }
        }

        SpawnNewBoard();
    }
    private void SpawnNewBoard()
    {
        ScoreBoardListing[] objectInChild = content.gameObject.GetComponentsInChildren<ScoreBoardListing>();
        foreach (ScoreBoardListing obj in objectInChild)
        {
            Destroy(obj);
        }

        foreach(ScoreBoardListing obj in listingList)
        {
            Instantiate(scoreBoardListing, content);
        }
    }
}
