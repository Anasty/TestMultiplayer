using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionResponceMessageUI : MonoBehaviour
{

    [SerializeField]
    private Text messageText;

    private void Start()
    {
        GameMultiplayer.Instance.onFailedToJoinGame += OnFailedToJoinGame;
    }

    private void OnFailedToJoinGame()
    {
        messageText.text = NetworkManager.Singleton.DisconnectReason;

        if (string.IsNullOrWhiteSpace(messageText.text))
        {
            messageText.text = "Failed to connect";

        }
    }

    private void OnDestroy()
    {

        GameMultiplayer.Instance.onFailedToJoinGame -= OnFailedToJoinGame;
    }
}
