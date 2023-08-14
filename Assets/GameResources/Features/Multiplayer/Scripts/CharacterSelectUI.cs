using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour
{
    [SerializeField]
    private Button menuButton;
    [SerializeField]
    private Button readyButton;
    [SerializeField]
    private Text lobbyName;
    [SerializeField]
    private Text lobbyCode;


    private void Awake()
    {
        menuButton.onClick.AddListener(() =>
        {
            GameLobby.Instance.LeaveLobby();
            NetworkManager.Singleton.Shutdown();
            NetworkManager.Singleton.SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        });
        readyButton.onClick.AddListener(() =>
        {
            CharacterSelectReady.Instance.SetPlayerReady();
        });
    }

    private void Start()
    {
        Lobby lobby = GameLobby.Instance.GetLobby();
        lobbyName.text = "LobbyName: " + lobby.Name;

        lobbyCode.text = "LobbyCode: " + lobby.LobbyCode;
    }
}
