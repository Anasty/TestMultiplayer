using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Расширение для корутин
/// </summary>
public class CoroutineExtension 
{
    private MonoBehaviour ovner;

    private Coroutine coroutine;
    public Coroutine Coroutine
    {
        get
        {
            return coroutine;
        }
        set
        {
            if (coroutine != null)
            {
                ovner.StopCoroutine(coroutine);
            }
            coroutine = value;
        }
    }

    public CoroutineExtension(MonoBehaviour ovner)
    {
        this.ovner = ovner;
    }
    
}
