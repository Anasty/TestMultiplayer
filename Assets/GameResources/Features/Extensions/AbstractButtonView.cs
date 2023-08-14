using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Абстрактная кнопка
/// </summary>
[RequireComponent(typeof(Button))]
public abstract class AbstractButtonView : MonoBehaviour
{
    protected Button button;
    protected virtual void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }
    public abstract void OnButtonClick();

    protected virtual void OnDestroy()
    {
        button.onClick.RemoveListener(OnButtonClick);
    }
}
