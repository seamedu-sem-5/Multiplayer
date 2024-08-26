using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayer : MonoBehaviourPunCallbacks
{
    public GameObject playePrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.CountOfPlayers == 0)
        {
            PhotonNetwork.Instantiate(playePrefab.name, this.transform.position, this.transform.rotation);
        }
        else
        {
            Vector3 spawnPos = this.transform.position + new Vector3(10 * PhotonNetwork.CountOfPlayers,0,0);
            PhotonNetwork.Instantiate(playePrefab.name, this.transform.position, this.transform.rotation);
        }
    }

}
