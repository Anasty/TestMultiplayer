using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Services.Lobbies.Models;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour
{
    [SerializeField]
    private Button mainMenuButton;
    [SerializeField]
    private Button createLobbyButton;
    [SerializeField]
    private Button quickJoinButton;
    [SerializeField]
    private Button joinCodeButton;
    [SerializeField]
    private InputField joinCodeInputField;
    [SerializeField]
    private InputField playerNameInputField;
    [SerializeField]
    private LobbyCreateUI lobbyCreateUI;
    [SerializeField]
    private Transform lobbyContainer;
    [SerializeField]
    private Transform lobbyTemplate;

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("MainMenu");
            GameLobby.Instance.LeaveLobby();
        });
        createLobbyButton.onClick.AddListener(() =>
        {
            lobbyCreateUI.gameObject.SetActive(true);
        });
        quickJoinButton.onClick.AddListener(() =>
        {
            GameLobby.Instance.QuickJoin();
        });
        joinCodeButton.onClick.AddListener(() =>
        {
            GameLobby.Instance.JoinWithCode(joinCodeInputField.text);
        });
        lobbyTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        playerNameInputField.text = GameMultiplayer.Instance.GetPlayerName();
        playerNameInputField.onValueChanged.AddListener((string Text) =>
        {
            GameMultiplayer.Instance.SetPlayerName(Text);
        });

        GameLobby.Instance.onLobbyListChanged += OnLobbyListChanged;

        UpdateLobbyList(new List<Lobby>());
    }

    private void OnLobbyListChanged(GameLobby.OnLobbyListChangedEventArgs list)
    {

        UpdateLobbyList(list.lobbyList);
    }

    private void UpdateLobbyList(List<Lobby> lobbyList)
    {
        foreach (Transform chaild in lobbyContainer)
        {
            if (chaild == lobbyTemplate)
            {
                continue;
            }
            Destroy(chaild.gameObject);
        }

        foreach (Lobby lobby in lobbyList)
        {
            Transform lobbyTransform = Instantiate(lobbyTemplate, lobbyContainer);
            lobbyTransform.gameObject.SetActive(true);
            lobbyTransform.GetComponent<LobbyListUiElement>().SetLobby(lobby);
        }
    }

    private void OnDestroy()
    {

        GameLobby.Instance.onLobbyListChanged -= OnLobbyListChanged;
    }
}
