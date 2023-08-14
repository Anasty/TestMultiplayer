using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Кнопка для загрузки сцены по названию
/// </summary>
public class LoadSceneButton : AbstractButtonView
{
    [SerializeField]
    private string sceneName;

    public override void OnButtonClick()
    {
        SceneManager.LoadScene(sceneName);
        // NetworkManager.Singleton.SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
