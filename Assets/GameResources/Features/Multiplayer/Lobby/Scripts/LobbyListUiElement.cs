using System.Collections;
using System.Collections.Generic;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.UI;

public class LobbyListUiElement : AbstractButtonView
{
    [SerializeField]
    private Text lobbyNameText;


    private Lobby lobby;


    public void SetLobby(Lobby lobby)
    {
        this.lobby = lobby;
        lobbyNameText.text = lobby.Name;
    }

    public override void OnButtonClick()
    {
        GameLobby.Instance.JoinWithId(lobby.Id);
    }
}
