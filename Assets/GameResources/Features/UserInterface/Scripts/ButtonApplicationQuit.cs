using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Кнопка для выхода из игры
/// </summary>
public class ButtonApplicationQuit : AbstractButtonView
{
    public override void OnButtonClick()
    {
        Application.Quit();
    }

}
