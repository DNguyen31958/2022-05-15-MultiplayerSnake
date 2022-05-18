using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class LobbyHolder : MonoBehaviourPunCallbacks
{
    public static string _roomName;
    public TMP_Text _createText;
    public TMP_Text _joinText;
    public TMP_Text _messageText;

    public void Start()
    {
        _messageText.text = "";
    }

    public void OnClick_CreateRoom()
    {
        if(_createText.text.Length <= 1)
        {
            FailConnectText();
        }
        else
        {
            SetRoomText(_createText.text);
            ConnectingText();
            PhotonNetwork.CreateRoom(_createText.text);
        }
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        FailConnectText();
    }

    public void OnClick_JoinRoom()
    {
        if(_joinText.text.Length <= 1)
        {
            FailConnectText();
        }
        else
        {
            SetRoomText(_joinText.text);
            ConnectingText();
            PhotonNetwork.JoinRoom(_joinText.text);
        }
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("2 Game");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        FailConnectText();
    }

    private void SetRoomText(string roomName)
    {
        _roomName = roomName;
    }

    private void ConnectingText()
    {
        _messageText.text  = "Connecting...";
    }

    private void FailConnectText()
    {
        StartCoroutine(SetTextCoroutine("Room Failed"));
    }

    IEnumerator SetTextCoroutine(string message){
        _messageText.text = message;
        yield return new WaitForSeconds(1.0f);
        _messageText.text = "";
        yield return null;
    }
}
