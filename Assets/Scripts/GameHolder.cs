using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameHolder : MonoBehaviour
{
    public TMP_Text _roomName;
    public static bool _isFoodActive;
    public TMP_Text _messageText;

    void Start()
    {
        _isFoodActive = false;
        _roomName.text = "Room Name: " + LobbyHolder._roomName;
        _messageText.text = "";
    }

    public void SetMessageText(string message)
    {
        StartCoroutine(SetTextCoroutine(message));
    }

    IEnumerator SetTextCoroutine(string message){
        _messageText.text = message;
        yield return new WaitForSeconds(1.0f);
        _messageText.text = "";
        yield return null;
    }

}
