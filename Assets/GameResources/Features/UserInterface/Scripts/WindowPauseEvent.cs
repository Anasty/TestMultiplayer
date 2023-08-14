using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Окно с паузой
/// </summary>
public class WindowPauseEvent : MonoBehaviour
{
    private void OnEnable()
    {
        if (GamePauseController.CurrentState != GamePauseController.GameState.Pause)
        {
            GamePauseController.ChangeGameState(true);
        }
    }

    private void OnDisable()
    {
        GamePauseController.ChangeGameState(false);
    }
}
