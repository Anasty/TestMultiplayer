using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer bodyMesh;
    [SerializeField]
    private MeshRenderer headMesh;

    private Material material;

    private void Awake()
    {
        material = new Material(headMesh.material);

        headMesh.material = material;
        bodyMesh.material = material;

        // PlayerData playerData = GameMultiplayer.Instance.GetPlayerDataFromClientId(OwnerClientId);
        //SetPlayerColor(GameMultiplayer.Instance.GetPlayerColor(playerData.colorId));
    }

    public void SetPlayerColor(Color color)
    {
        material.color = color;
    }
}
