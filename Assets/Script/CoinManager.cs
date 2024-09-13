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
    public List<Vector3> destroyedCoinPosList;

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
        if(PhotonNetwork.IsMasterClient)
        {
            InstantiateCoin();
        }
    }
    public void InstantiateCoin()
    {
        randomPosList = new List<Vector3>();

        for (int i = 0; i < numberOfCoin; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(minXY.x, maxXY.x), 0.5f, Random.Range(minXY.z, maxXY.x));
            randomPosList.Add(randomPos);
        }
        foreach (var pos in randomPosList)
        {
            PhotonNetwork.Instantiate(coin.name, pos, Quaternion.identity);
        }
    }

    public float[] Vector3ListToFloatArry(List<Vector3> list)
    {
        float[] array = new float[list.Count*3];
        for(int i = 0;i < list.Count;i++)
        {
            array[i*3] = list[i].x;
            array[(i*3) + 1] = list[i].y;
            array[(i*3) + 2] = list[i].z;
        }
        return array;
    }
    public List<Vector3> FloatArrayToVector3List(float[] array)
    {
        List<Vector3> list = new List<Vector3>();
        for(int i = 0; i < array.Length;i+=3)
        {
            Vector3 vector = new Vector3(array[i], array[i+1], array[i+2]);
            list.Add(vector);
        }
        return list;
    }
}
