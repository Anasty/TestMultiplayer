using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectPlayer : MonoBehaviour
{

    [SerializeField]
    private int playerIndex;
    [SerializeField]
    private GameObject readyGameObject;

    [SerializeField]
    private PlayerVisual playerVisual;
    [SerializeField]
    private Button kickButton;
    [SerializeField]
    private Text playerNameText;

    private void Awake()
    {
        kickButton.onClick.AddListener(() =>
        {
            PlayerData playerData = GameMultiplayer.Instance.GetPlayerDataFromPlayerIndex(playerIndex);
            GameLobby.Instance.KickPlayer(playerData.playerId.ToString());
            GameMultiplayer.Instance.KickPlayer(playerData.clientId);
        });
    }

    private void Start()
    {
        GameMultiplayer.Instance.onPlayerDataNetworkListChanged += OnPlayerDataNetworkListChanged;
        CharacterSelectReady.Instance.onReadyChanged += OnReadyChanged;


        kickButton.gameObject.SetActive(NetworkManager.Singleton.IsServer);
        UpdatePlayer();
    }

    private void OnReadyChanged()
    {
        UpdatePlayer();
    }

    private void UpdatePlayer()
    {
        if (GameMultiplayer.Instance.IsPlayerIndexConnected(playerIndex))
        {
            gameObject.SetActive(true);

            PlayerData playerData = GameMultiplayer.Instance.GetPlayerDataFromPlayerIndex(playerIndex);
            readyGameObject.SetActive(CharacterSelectReady.Instance.IsPlayerReady(playerData.clientId));

            if (playerNameText)
            {
                playerNameText.text = playerData.playerName.ToString();
            }
            playerVisual.SetPlayerColor(GameMultiplayer.Instance.GetPlayerColor(playerData.colorId));
        }
        else
        {

            gameObject.SetActive(false);
        }
    }

    private void OnPlayerDataNetworkListChanged()
    {
        UpdatePlayer();
    }

    private void OnDestroy()
    {
        GameMultiplayer.Instance.onPlayerDataNetworkListChanged -= OnPlayerDataNetworkListChanged;
        CharacterSelectReady.Instance.onReadyChanged -= OnReadyChanged;

    }
}
