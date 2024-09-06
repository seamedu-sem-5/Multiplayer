using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PhotonView photonView = other.gameObject.GetComponent<PhotonView>();
        if( photonView != null && photonView.IsMine)
        {
            CoinManager.instance.AddScore(1);
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
