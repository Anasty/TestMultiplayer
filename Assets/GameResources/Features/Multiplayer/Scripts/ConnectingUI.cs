using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectingUI : MonoBehaviour
{

    private void Start()
    {
        GameMultiplayer.Instance.onTryingToJoinGame += OnTryingToJoinGame;
        GameMultiplayer.Instance.onFailedToJoinGame += OnFailedToJoinGame;
        gameObject.SetActive(false);
    }

    private void OnFailedToJoinGame()
    {
        gameObject.SetActive(false);
    }

    private void OnTryingToJoinGame()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameMultiplayer.Instance.onTryingToJoinGame -= OnTryingToJoinGame;
        GameMultiplayer.Instance.onFailedToJoinGame -= OnFailedToJoinGame;

    }
}
