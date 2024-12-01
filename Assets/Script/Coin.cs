using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement pm) && other.TryGetComponent<PhotonView>(out PhotonView pv))
        {
            if (pv.IsMine)
            {
                CoinManager.instance.AddScore(1);
            }
        }

        if (GetComponent<PhotonView>() != null)
        {
            DestroyList();
            GetComponent<PhotonView>().RPC("DestroyList", RpcTarget.Others);
        }
    }

    [PunRPC]
    public void DestroyList()
    {
        Destroy(this.gameObject);
    }
}
