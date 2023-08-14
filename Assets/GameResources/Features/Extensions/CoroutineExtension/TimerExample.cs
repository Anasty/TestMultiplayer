using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Пример для работы с CoroutineExtension
/// </summary>
public class TimerExample : MonoBehaviour
{
    private int time = 0;
    private CoroutineExtension coroutine;
    private void Awake()
    {
        coroutine = new CoroutineExtension(this);
    }

    public void StartTimer()
    {
        coroutine.Coroutine = StartCoroutine(Timer());
    }

    public void StopTimer()
    {
        coroutine.Coroutine = null;
    }

    private IEnumerator Timer()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(1f);
            time++;
            Debug.Log(time);
        }            
    }
}
