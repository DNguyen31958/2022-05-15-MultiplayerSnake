using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PingCounter : MonoBehaviourPunCallbacks
{
    public TMP_Text _pingText;

    void Update()
    {
        _pingText.text = "Ping: " + PhotonNetwork.GetPing();
    }
}
