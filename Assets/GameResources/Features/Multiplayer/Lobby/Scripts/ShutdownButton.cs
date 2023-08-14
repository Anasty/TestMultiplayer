using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ShutdownButton : AbstractButtonView
{
    public override void OnButtonClick()
    {
        NetworkManager.Singleton.Shutdown();
    }
}
