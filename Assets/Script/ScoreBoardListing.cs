using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Realtime;
public class ScoreBoardListing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI scoreText;
    public int score;

    public Player playerInfo { get; set; }
    public void SetPlayerInfo(Player _player)
    {
        playerInfo = _player;
        nameText.text = playerInfo.NickName;// Display the player's nickname
        scoreText.text = _player.CustomProperties["score"].ToString();
        score = int.Parse(scoreText.text);
    }
}
