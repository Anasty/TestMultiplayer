using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Расширение для списков геймобжектов
/// </summary>
public static class ListExtensions
{
    public static void SetActiveAll(this List<GameObject> list, bool isActive)
    {
        foreach (GameObject obj in list)
        {
            obj.SetActive(isActive);
        }
    }
}
