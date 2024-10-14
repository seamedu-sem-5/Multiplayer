using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GameManager : MonoBehaviourPun
{
    public static GameManager Instance;
    public int coinsToWinTheGame;
    [SerializeField]string sceneName;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void GameOver()
    {
        if(this.GetComponent<PhotonView>() != null)
        {
            this.GetComponent<PhotonView>().RPC("ChangeScene", RpcTarget.MasterClient);
        }
    }

    [PunRPC]
    private void ChangeScene()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(sceneName);
        }
    }
}
