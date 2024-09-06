using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class CoinManager : MonoBehaviour
{
    public Coin coin;
    public Vector3 minXY;
    public Vector3 maxXY;
    public int numberOfCoin;
    List<Vector3> randomPosList;

    public TextMeshProUGUI scoreText;
    public static CoinManager instance;
    public int score;
    Hashtable scoreHashtable = new Hashtable();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public void AddScore(int valueToAdd)
    {
        score += valueToAdd;
        scoreText.text = score.ToString();
        scoreHashtable["score"] = score;
        PhotonNetwork.LocalPlayer.SetCustomProperties(scoreHashtable);
    }

    private void Start()
    {
        randomPosList = new List<Vector3>();

        for(int i = 0; i < numberOfCoin; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(minXY.x,maxXY.x),0.5f,Random.Range(minXY.z,maxXY.x));
            randomPosList.Add(randomPos);
        }

        foreach(Vector3 randomPos in randomPosList)
        {
            PhotonNetwork.Instantiate(coin.name, randomPos, Quaternion.identity);
        }
    }
}
