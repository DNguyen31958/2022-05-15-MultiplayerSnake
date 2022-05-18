using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using TMPro;

public class StartMenuHolder : MonoBehaviourPunCallbacks
{
    public TMP_Text _messageText;
    public TMP_Text _nickNameText;

    private void Start()
    {
        _messageText.text = "";
    }

    public void OnClick_StartGame()
    {
        // if(_nickNameText.text.Length <= 1)
        // {
        //     _messageText.text = "Enter Nickname";
        //     return;
        // }
        // PhotonNetwork.NickName = _nickNameText.text;
        _messageText.text = "Connecting...";
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("1 Lobby");
    }
}
