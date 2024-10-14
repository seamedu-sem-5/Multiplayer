using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;


public class DisplayPlayerName : MonoBehaviour
{
    public TMP_Text TMP_Text;
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text.text = PhotonNetwork.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
