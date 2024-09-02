using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListing : MonoBehaviour
{
    private TMP_Text _playerListingText;

    public Player playerInfo { get; set; }

    private void Awake()
    {
        _playerListingText = GetComponentInChildren<TMP_Text>();
    }
    public void SetPlayerInfo(Player _player)
    {
        playerInfo = _player;
        _playerListingText.text = playerInfo.NickName;
    }

}
