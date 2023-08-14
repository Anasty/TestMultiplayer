using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Компонент для отключения курсора во время игры
/// </summary>
public class CursorController : MonoBehaviour
{
    [SerializeField]
    private bool hideCursorOnEnable = true;

    private void OnEnable()
    {
        ChangeCursorState(hideCursorOnEnable ? false : true);
    }

    private void ChangeCursorState(bool isActive)
    {
        if (!isActive)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnDisable()
    {

        ChangeCursorState(hideCursorOnEnable ? true : false);
    }
}
