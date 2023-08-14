using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePlayerInputWindow : MonoBehaviour
{
    private FpsController fpsController = default;

    private void Awake()
    {
        fpsController = FindObjectOfType<FpsController>();
    }

    private void OnEnable()
    {
        fpsController.UnlockPlayerInput(false);
    }

    private void OnDisable()
    {
        fpsController.UnlockPlayerInput(true);
    }
}
