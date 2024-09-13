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
            CoinManager.instance.destroyedCoinPosList.Add(transform.position);
        }

        float[] arrayOfDestroyedObject = CoinManager.instance.Vector3ListToFloatArry(CoinManager.instance.destroyedCoinPosList);

        if(GetComponent<PhotonView>() != null)
        {
            GetComponent<PhotonView>().RPC("DestroyList", RpcTarget.All, arrayOfDestroyedObject);
        }
    }

    [PunRPC]
    public void DestroyList(float[] arrayOfDestroyedObject)
    {
        List<Vector3> list = CoinManager.instance.FloatArrayToVector3List(arrayOfDestroyedObject);
        GameObject[] coinList= GameObject.FindGameObjectsWithTag("Coin");
        foreach(Vector3 v in list)
        {
            foreach(GameObject coin in coinList)
            {
                if(Vector3.Distance(v, coin.transform.position) < 0.1f)
                {
                    Destroy(coin);
                }
            }
        }
    }
}
