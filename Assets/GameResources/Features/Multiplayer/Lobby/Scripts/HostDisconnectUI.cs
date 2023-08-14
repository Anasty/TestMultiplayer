using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class HostDisconnectUI : MonoBehaviour
{
    private void Start()
    {
        NetworkManager.Singleton.OnClientDisconnectCallback += Singleton_OnClientDisconnectCallback;
        gameObject.SetActive(false);
    }

    private void Singleton_OnClientDisconnectCallback(ulong cliendId)
    {
        if (cliendId == NetworkManager.ServerClientId)
        {

            gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        if (NetworkManager.Singleton != null)
            NetworkManager.Singleton.OnClientDisconnectCallback -= Singleton_OnClientDisconnectCallback;
    }
}
