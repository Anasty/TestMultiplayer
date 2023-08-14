using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Контроллер паузы в игре
/// </summary>
public static class GamePauseController
{
    public static event Action onGameStateChanged = delegate { };

    //TODO: возвращение к предыдущему значению таймскейла при снятии паузы
    private static float lastTimeScale;

    public enum GameState
    {
        Pause,
        Active
    }

    public static GameState CurrentState { get; private set; } = GameState.Active;

    /// <summary>
    /// Изменяет состояние игры
    /// </summary>
    /// <param name="isPause"></param>
    public static void ChangeGameState(bool isPause)
    {
        if (isPause)
        {
            Time.timeScale = 0f;
            CurrentState = GameState.Pause;
        }
        else
        {
            Time.timeScale = 1f;
            CurrentState = GameState.Active;
        }

        onGameStateChanged.Invoke();
    }
}
