using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ConnectionResponceMessageUI : MonoBehaviour
{

    [SerializeField]
    private Text _messageText = default;

    private void Start()
    {

        GameMultiplayer.Instance.onFailedToJoinGame += OnFailedToJoinGame;
        GameLobby.Instance.onCreateLobbyFailed += OnCreateLobbyFailed;
        GameLobby.Instance.onCreateLobbyStarted += OnCreateLobbyStarted;
        GameLobby.Instance.onJoinStarted += OnJoinStarted;
        GameLobby.Instance.onJoinFailed += OnJoinFailed;
        GameLobby.Instance.onQuickJoinFailed += OnQuickJoinFailed;
        gameObject.SetActive(false);
    }

    private void OnQuickJoinFailed()
    {
        ShowMessage("Could not find a Lobby to Quick Join!");
    }

    private void OnJoinFailed()
    {
        ShowMessage("Failed to join Lobby");
    }

    private void OnJoinStarted()
    {
        ShowMessage("Joining Lobby...");
    }

    private void OnCreateLobbyStarted()
    {
        ShowMessage("Creating Lobby...");
    }

    private void OnCreateLobbyFailed()
    {
        ShowMessage("Failed to create Lobby");
    }

    private void OnFailedToJoinGame()
    {
        if (string.IsNullOrWhiteSpace(NetworkManager.Singleton.DisconnectReason))
        {
            ShowMessage("Failed to connect");
        }
        else
        {
            ShowMessage(NetworkManager.Singleton.DisconnectReason);
        }
    }

    private void ShowMessage(string message)
    {
        gameObject.SetActive(true);
        _messageText.text = message;

        if (string.IsNullOrWhiteSpace(_messageText.text))
        {
            _messageText.text = "Failed to connect";

        }

    }

    private void OnDestroy()
    {

        GameMultiplayer.Instance.onFailedToJoinGame -= OnFailedToJoinGame;
    }
}
