using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyCreateUI : MonoBehaviour
{
    [SerializeField]
    private Button closeButton;

    [SerializeField]
    private Button createPublicButton;
    [SerializeField]
    private Button createPrivateButton;
    [SerializeField]
    private InputField lobbynameInputField;

    private void Awake()
    {
        createPublicButton.onClick.AddListener(() =>
        {
            GameLobby.Instance.CreateLobby(lobbynameInputField.text, false);
        });
        createPrivateButton.onClick.AddListener(() =>
        {
            GameLobby.Instance.CreateLobby(lobbynameInputField.text, true);
        });
        closeButton.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });
        gameObject.SetActive(false);
    }
}
